﻿namespace ChallengeTechAndSolve.Extensions
{
    using ChallengeTechAndSolve.Resources;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;
        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            var extension = Path.GetExtension(file.FileName);
            if (file != null)
            {
                if (!_extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult(string.Format(WebUiResources.AllowTxt, extension.ToLower()));
                }
            }

            return ValidationResult.Success;
        }
    }
}