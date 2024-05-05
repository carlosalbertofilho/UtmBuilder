using System;
using System.Web;
using UtmBuilder.Core.ValueObjects.Extensions;

namespace UtmBuilder.Core.ValueObjects;

public class Url : ValueObject
{
    /// <summary>
    /// Address of URL (Website link)
    /// </summary>
    public string Address { get; }

    /// <summary>s
    /// Create a new URL
    /// </summary>
    /// <param name="address">Address of URL (Website link)</param>
    public Url (
        string address )
    {
        Address = address;
        InvalidUrlException.ThrowIfInvalid( address, "Address cannot be null or empty" );
    }

    /// <summary>
    /// return the segments of the URL
    /// case the URL is invalid thorws an InvalidUrlException
    /// 
    public UtmParameters GetSegments ()
    {
        var segments = Address.Split("?");

        if ( segments.Length == 1 )
            throw new InvalidUrlException();
        var uri = new Uri(Address);
        var queryParams = HttpUtility.ParseQueryString(uri.Query);

        var source = queryParams[$"{UtmKey.UtmSource}"] ?? string.Empty;
        var medium = queryParams[$"{UtmKey.UtmMedium}"] ?? string.Empty;
        var name = queryParams[$"{UtmKey.UtmCampaign}"] ?? string.Empty;
        var id = queryParams[$"{UtmKey.UtmId}"];
        var term = queryParams[$"{UtmKey.UtmTerm}"];
        var content = queryParams[$"{UtmKey.UtmContent}"];

        return new UtmParameters( source, medium, name, id, term, content );
    }

}
