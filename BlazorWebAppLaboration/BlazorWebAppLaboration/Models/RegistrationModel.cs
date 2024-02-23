﻿using System.ComponentModel.DataAnnotations;

namespace BlazorLaboration.Models
{
    public class RegistrationModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
        
    }
}
