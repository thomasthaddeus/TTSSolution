using System.Reflection;

namespace Tests
{
    [TestFixture]
    public class PowerPointScraperTests
    {
        private PowerPointScraper _powerPointScraper;

        [SetUp]
        public void SetUp()
        {
            _powerPointScraper = new PowerPointScraper();
        }

        [Test]
        public void ExtractTextFromPresentation_ValidFile_ReturnsText()
        {
            // Prepare
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestData", "SamplePresentation.pptx");

            // Act
            IList<string> result = _powerPointScraper.ExtractTextFromPresentation(filePath);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("Slide 1 Title", result[0]);
            Assert.AreEqual("Slide 1 Content", result[1]);
            Assert.AreEqual("Slide 2 Title", result[2]);
        }
    }
}