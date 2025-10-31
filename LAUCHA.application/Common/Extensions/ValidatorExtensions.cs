namespace LAUCHA.application.Common.Extensions
{
    internal static class ValidatorExtensions
    {
        public static string ToMessageString(this FluentValidation.Results.ValidationResult result)
        {
            if (result.IsValid)
                return string.Empty;

            return string.Join(
                "; ",
                result.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}")
            );
        }
    }
}
