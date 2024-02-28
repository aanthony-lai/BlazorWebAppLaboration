using BlazorLaboration.Data;
using BlazorWebAppLaboration.Plugins;
using Microsoft.EntityFrameworkCore;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace BlazorWebAppLaboration.Services
{
	public class OpenAIService
	{
		public ChatHistory history { get; set; } = [];
		private readonly IKernelBuilder? builder;
		private readonly IChatCompletionService? chatCompletionService;
		private readonly IDbContextFactory<AppDbContext> dbContextFactory;
		private readonly Kernel? kernel;
		private readonly string modelId;
		private readonly string key; 
		bool isSent = false;

		public OpenAIService(IDbContextFactory<AppDbContext> DbContextFactory, IConfiguration configuration)
		{
			modelId = configuration.GetSection("OpenAI:ModelID").Value ?? string.Empty;
			key = configuration.GetSection("OpenAI:Key").Value ?? string.Empty;

			dbContextFactory = DbContextFactory;
			builder = Kernel.CreateBuilder();
			builder.AddOpenAIChatCompletion(modelId, key);
			builder.Plugins.AddFromObject(new ProductPlugin(dbContextFactory), nameof(ProductPlugin));
			kernel = builder.Build();
			history.AddSystemMessage("You are a helpful AI Web Shop Assistant. " +
				"Your job is to help our customers with their questions. The answers you provide should be in fluent" +
				"text and never resemble the output you get directly from the database. " +
				" Don't ever use bullet points in your replies. " +
				"Please try to be casual and communicate in a human like language. " +
				"You are capable of answering questions about products, restocking products as well as editing descriptions. ");

			chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
		}

		public async Task<ChatHistory> SendMessage(string userMessage)
		{
			isSent = !isSent;

			while (isSent)
			{
				history.AddUserMessage(userMessage);

				OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new()
				{
					ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
				};

				isSent = !isSent;
			}
			return history;
		}

		public async Task<ChatHistory> Response()
		{
			isSent = !isSent;
			while(isSent)
			{
				OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new()
				{
					ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
				};

				var response = chatCompletionService.GetStreamingChatMessageContentsAsync(
											history,
											openAIPromptExecutionSettings,
											kernel: kernel);

				string combinedResponse = string.Empty;
				await foreach (var message in response)
				{
					Console.Write(message);
					combinedResponse += message;
				}

				history.AddAssistantMessage(combinedResponse);
				isSent = !isSent;
			}
			
			return history;
		}
	}
}
