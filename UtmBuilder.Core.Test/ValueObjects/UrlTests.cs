using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Extensions;

namespace UtmBuilder.Core.Test.ValueObjects;

[TestClass]
public class UrlTests
{
    private const string ValidUrl = "https://balta.io" +
        "?utm_source=source" +
        "&utm_medium=medium" +
        "&utm_campaign=campaign" +
        "&utm_id=id" +
        "&utm_term=term" +
        "&utm_content=content";


    [TestMethod( "It should return an exception if the url is invalid" )]
    [TestCategory( "ValueObjects/Url" )]
    [ExpectedException( typeof( InvalidUrlException ) )]
    [DataRow( " " )]
    [DataRow( "Bamama" )]
    [DataRow( "https://balta.io" )]
    [DataRow( "https://balta.io?utm_source=source" )]
    [DataRow( "https://balta.io?utm_source=source&utm_medium=medium" )]
    public void ItShouldRetornExceptionIfTheUrlIsInvalid (string invalidUrl)
    {
        _ = new Url( invalidUrl );
    }

    [TestMethod( "It should not return an exception if the url is valid" )]
    [TestCategory( "ValueObjects/Url" )]
    public void ItShouldNotReturnExceptionIfTheUrlIsValid ()
    {
        _ = new Url( ValidUrl );
    }

    [TestMethod( "It should return the segments of the URL" )]
    [TestCategory( "ValueObjects/Url" )]
    public void ItShouldReturnTheSegmentsOfTheUrl ()
    {
        // Arrange
        var url = new Url(ValidUrl);

        // Act
        var segments = url.GetSegments();

        // Assert
        Assert.AreEqual( "source", segments.Source );
        Assert.AreEqual( "medium", segments.Medium );
        Assert.AreEqual( "campaign", segments.Name );
        Assert.AreEqual( "id", segments.Id );
        Assert.AreEqual( "term", segments.Term );
        Assert.AreEqual( "content", segments.Content );
    }
}
