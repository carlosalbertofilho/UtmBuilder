using System.Text.RegularExpressions;

namespace UtmBuilder.Core.ValueObjects.Extensions;

public partial class InvalidUrlException (
    string message = InvalidUrlException.DefaultErrorMessage ) : Exception( message )
{
    private const string DefaultErrorMessage = "Invalid URL";
    [GeneratedRegex(
        "^(http|https):(\\/\\/www\\.|\\/\\/www\\.|\\/\\/|\\/\\/)[a-z0-9]+([\\-\\.]{1}[a-z0-9]+)*\\.[a-z]{2,5}(:[0-9]{1,5})?(\\/.*)?$|(http|https):(\\/\\/localhost:\\d*|\\/\\/127\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))(:[0-9]{1,5})?(\\/.*)?$" )]
    private static partial Regex UrlRegex ();
    /// <summary>
    /// Throws an InvalidUrlException if the item is null or empty or not a valid URL.
    /// </summary>
    /// <param name="item">Url parameters</param>
    /// <param name="message">Error message</param>
    /// <exception cref="InvalidUrlException"></exception>

    public static void ThrowIfInvalid (
        string address,
        string message = DefaultErrorMessage )
    {
        if ( string.IsNullOrEmpty( address ) )
            throw new InvalidUrlException( message );

        if ( !UrlRegex().IsMatch( address ) )
            throw new InvalidUrlException();
    }

}
