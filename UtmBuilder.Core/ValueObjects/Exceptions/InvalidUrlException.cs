using System.Text.RegularExpressions;

namespace UtmBuilder.Core.ValueObjects.Extensions;

public partial class InvalidUrlException (
    string message = InvalidUrlException.DefaultErrorMessage ) : Exception( message )
{
    private const string DefaultErrorMessage = "Invalid URL";
    [GeneratedRegex(
        "^(http|https):\\/\\/[^\\/\\s]+\\/?\\?(?=.*utm_source=[^&]+)(?=.*utm_medium=[^&]+)(?=.*utm_campaign=[^&]+)(?=.*utm_id=[^&]*)?(?=.*utm_term=[^&]*)?(?=.*utm_content=[^&]*)?.*" )]
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
