﻿using System;
using System.Web;
using UtmBuilder.Core.ValueObjects.Extensions;

namespace UtmBuilder.Core.ValueObjects;

public class Url : ValueObject
{
    /// <summary>
    /// Address of URL (Website link)
    /// </summary>
    public string Address { get; }

    /// <summary>
    /// Domain URL
    /// </summary>
    public string DomainUrl { get; }

    /// <summary>
    /// Query String contains the UTM parameters
    /// </summary>
    public string QueryString { get; }

    /// <summary>s
    /// Create a new URL
    /// </summary>
    /// <param name="address">Address of URL (Website link)</param>
    /// 
    public Url (
        string address )
    {
        InvalidUrlException.ThrowIfInvalid( address, "Address cannot be null or empty" );
        Address = address;
        DomainUrl = Address.Split( '?' )[ 0 ];
        QueryString = Address.Split( '?' )[ 1 ];
    }

    /// <summary>
    /// return the segments of the URL
    /// case the URL is invalid thorws an InvalidUrlException
    /// </summary>
    public UtmParameters GetSegments ()
    {

        var queryParams = HttpUtility.ParseQueryString(QueryString);

        var source = queryParams["utm_source"] ?? string.Empty;
        var medium = queryParams["utm_medium"] ?? string.Empty;
        var name = queryParams["utm_campaign"] ?? string.Empty;
        var id = queryParams["utm_id"];
        var term = queryParams["utm_term"];
        var content = queryParams["utm_content"];

        return new UtmParameters( source, medium, name, id, term, content );
    }

}
