﻿namespace GameZone.Attribute
{
	public class MaxFileSizeAttribute : ValidationAttribute
	{
		public readonly int _maxFileSize;

		public MaxFileSizeAttribute(int maxFileSize)
		{
			_maxFileSize = maxFileSize;
		}

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var file = value as IFormFile;
			if(file != null)
			{
				if (file.Length > _maxFileSize)
				{
					return new ValidationResult($"Maximum allowed size is {Settings.FileSettings.MaxFileInMB} MB!");
				}
			}

			return ValidationResult.Success;
		}
	}
}
