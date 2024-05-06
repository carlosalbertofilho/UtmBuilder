
using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Extensions;

namespace UtmBuilder.Core.Test.ValueObjects;

[TestClass]
public class CampaingTests
{
        private const string ValidUrl = "https://balta.io" +
        "?utm_source=source" +
        "&utm_medium=medium" +
        "&utm_campaign=campaign" +
        "&utm_id=id" +
        "&utm_term=term" +
        "&utm_content=content";

    [TestMethod("It should return an exception if Campaing parameters is invalid")]
    [TestCategory("ValueObjects/Campaing")]
    [ExpectedException( typeof( InvalidCampaignException ) )]
    [DataRow(" ", "medium", "campaign")]
    [DataRow("source", " ", "campaign")]
    [DataRow("source", "medium", " ")]
    public void ItShouldRetornExceptionIfTheCampaingParametersIsInvalid(string source, string medium, string campaign)
    {
        _ = new Campaign( source, medium, campaign );
    }

    [TestMethod("It should not return an exception if the Campaing parameters is valid")]
    [TestCategory("ValueObjects/Campaing")]
    public void ItShouldNotReturnExceptionIfTheCampaingParametersIsValid()
    {
        _ = new Campaign( "source", "medium", "campaign" );
        _ = new Campaign( "source", "medium", "campaign", "id" );
        _ = new Campaign( "source", "medium", "campaign", "id", "term" );
        _ = new Campaign( "source", "medium", "campaign", "id", "term", "content" );
    }

    [TestMethod("It should return a Campaing object's contain the segments of the URL")]
    [TestCategory("ValueObjects/Campaing")]
    public void ItShouldReturnACampaingObjectContainTheSegmentsOfTheUrl()
    {
        // Arrange
        var url = new Url(ValidUrl);
        var campaing = new Campaign( url );

        // Assert
        Assert.AreEqual("source", campaing.Source);
        Assert.AreEqual("medium", campaing.Medium);
        Assert.AreEqual("campaign", campaing.Name);
        Assert.AreEqual("id", campaing.Id);
        Assert.AreEqual("term", campaing.Term);
        Assert.AreEqual("content", campaing.Content);
    }

}
