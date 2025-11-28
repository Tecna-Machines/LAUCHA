namespace LAUCHA.application.Common.Extensions
{
    public static class ResultExtensions
    {
        public static T Match<T>(
            this Result resullt,
            Func<T> onSucces,
            Func<Error, T> onFailure
            )
        {
            return resullt.IsSuccess ? onSucces() : onFailure(resullt.Error);
        }
    }
}
