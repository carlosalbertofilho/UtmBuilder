using System.Xml.Linq;
using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Extensions;

namespace UtmBuilder.Core;

/// <summary>
/// UTM Parameters
/// </summary>
/// <param name="url">Address parameters</param>
/// <param name="campaign">Generate a new campaign</param>
public class Utm (
    Url url,
    Campaign campaign )
{
    /// <summary>
    /// URL (Website Link)
    /// </summary>
    public Url Url { get; } = url;

    /// <summary>
    /// Campaign Details
    /// </summary>
    public Campaign Campaign { get; } = campaign;

    /// <summary>
    /// Cast UTM to string in implicit conversion
    /// 
    public static implicit operator string ( Utm utm )
        => utm.ToString();


    /// <summary>
    /// Cast URL to UTM in implicit conversion
    /// </summary>
    /// <param name="url"></param>
    public static implicit operator Utm ( string url )
    {
        var uri = new Url( url );
        var campaign = new Campaign(uri);

        return new Utm( uri, campaign );
    }

    /// <summary>
    /// Cast UTM to string
    /// 
    public override string ToString ()
    {
        var segment = new List<string>
    {
        $"{UtmKey.UtmSource}={Campaign.Source}",
        $"{UtmKey.UtmMedium}={Campaign.Medium}",
        $"{UtmKey.UtmCampaign}={Campaign.Name}",
        $"{UtmKey.UtmId}={Campaign.Id}",
        $"{UtmKey.UtmTerm}={Campaign.Term}",
        $"{UtmKey.UtmContent}={Campaign.Content}"
    };
        return $"{Url.Address}?{string.Join( "&", segment )}";
    }
}
