namespace LAUCHA.application.Common.Errors
{
    public sealed record Error(string? Descripcion = "error")
    {
        public static readonly Error None = new(string.Empty);
        public static readonly Error Null = new("Error.NullValue");

        public static implicit operator Result(Error error) => Result.Failure(error);
    }
}
