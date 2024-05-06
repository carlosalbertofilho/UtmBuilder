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
    /// </summary>  
    public static implicit operator string ( Utm utm )
        => utm.ToString();


    /// <summary>
    /// Cast URL to UTM in implicit conversion
    /// </summary>
    /// <param name="url"></param>
    /// 
    public static implicit operator Utm ( string url )
    {
        var uri = new Url( url );
        var campaign = new Campaign(uri);

        return new Utm( uri, campaign );
    }

    /// <summary>
    /// Cast UTM to string
    /// </summary>
    public override string ToString ()
    {
        var segment = new List<string>
        {
            $"utm_source={Campaign.Source}",
            $"utm_medium={Campaign.Medium}",
            $"utm_campaign={Campaign.Name}",
            $"utm_id={Campaign.Id}",
            $"utm_term={Campaign.Term}",
            $"utm_content={Campaign.Content}"
        };
        return $"{Url.DomainUrl}?{string.Join( "&", segment )}";
    }
}
