namespace UtmBuilder.Core.ValueObjects.Extensions;

public partial class InvalidCampaignException (
    string message = InvalidCampaignException.DefaultMessage ) : Exception( message )
{
    private const string DefaultMessage = "Invalid UTM parameters";
    /// <summary>
    /// Throws an InvalidCampaignException if the item is null or empty.
    /// </summary>
    /// <param name="item">Param of the campaign</param>
    /// <param name="message">Error message</param>
    /// <exception cref="InvalidCampaignException"></exception>
    public static void ThrowIfINull (
             string? item,
             string message = DefaultMessage)
    {
        if ( string.IsNullOrWhiteSpace( item) )
            throw new InvalidCampaignException( message );
    }
}
