using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Test;

[TestClass]
public class UtmTest
{
    [TestMethod("It should return a UTM object contain the Url and Campaign objects")]
    [TestCategory("Utm")]
    public void ItShouldReturnAUtmObjectContainTheUrlAndCampaignObjects()
    {
        // Arrange
        var address = "https://balta.io" +
            "?utm_source=source" +
            "&utm_medium=medium" +
            "&utm_campaign=campaign" +
            "&utm_id=id" +
            "&utm_term=term" +
            "&utm_content=content";
        var url = new Url(address);
        var campaign = new Campaign(url);

        // Act
        var utm = new Utm(url, campaign);

        // Assert
        Assert.AreEqual(address, utm.Url.Address);
        Assert.AreEqual("source", utm.Campaign.Source);
        Assert.AreEqual("medium", utm.Campaign.Medium);
        Assert.AreEqual("campaign", utm.Campaign.Name);
        Assert.AreEqual("id", utm.Campaign.Id);
        Assert.AreEqual("term", utm.Campaign.Term);
        Assert.AreEqual("content", utm.Campaign.Content);
    }

    [TestMethod("It should return a string from a UTM object")]
    [TestCategory("Utm")]
    public void ItShouldReturnAStringFromUtmObject()
    {
        // Arrange
        var address = "https://balta.io" +
            "?utm_source=source" +
            "&utm_medium=medium" +
            "&utm_campaign=campaign" +
            "&utm_id=id" +
            "&utm_term=term" +
            "&utm_content=content";
        var url = new Url(address);
        var campaign = new Campaign(url);
        var utm = new Utm(url, campaign);

        // Assert
        Assert.AreEqual(address, (string)utm);
    }

    [TestMethod("It should return a UTM object from a string")]
    [TestCategory("Utm")]
    public void ItShouldReturnAUtmObjectFromString()
    {
        // Arrange
        var address = "https://balta.io" +
            "?utm_source=source" +
            "&utm_medium=medium" +
            "&utm_campaign=campaign" +
            "&utm_id=id" +
            "&utm_term=term" +
            "&utm_content=content";

        // Act
        var utm = (Utm)address;

        // Assert
        Assert.AreEqual(address, utm.Url.Address);
        Assert.AreEqual("source", utm.Campaign.Source);
        Assert.AreEqual("medium", utm.Campaign.Medium);
        Assert.AreEqual("campaign", utm.Campaign.Name);
        Assert.AreEqual("id", utm.Campaign.Id);
        Assert.AreEqual("term", utm.Campaign.Term);
        Assert.AreEqual("content", utm.Campaign.Content);
    }
}
