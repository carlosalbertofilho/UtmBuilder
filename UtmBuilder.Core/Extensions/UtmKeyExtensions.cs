using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Extensions;

public static class UtmKeyExtensions
{
    public static string ToString(
        this UtmKey utmKey)
    {
        return utmKey switch
        {
            UtmKey.UtmSource => "utm_source",
            UtmKey.UtmMedium => "utm_medium",
            UtmKey.UtmCampaign => "utm_campaign",
            UtmKey.UtmId => "utm_id",
            UtmKey.UtmTerm => "utm_term",
            UtmKey.UtmContent => "utm_content",
            _ => throw new ArgumentOutOfRangeException( nameof( utmKey ), utmKey, null ),
        };
    }
}
