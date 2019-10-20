using System;
using System.ComponentModel.DataAnnotations;

namespace EasyModelValidator
{
    public static class EasyModelValidatorExtension
    {
        public static bool IsValid<T>(this T model)
        {
            try
            {
                var vc = new ValidationContext(model, null, null);
                var result = Validator.TryValidateObject(model, vc, null, true);
                return result;
            }
            catch (Exception e)
            {
                throw new ModelValidationException("Model Validation has Failed", e);
            }
        }
    }
}