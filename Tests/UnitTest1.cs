using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PptxScraper;
using TextToSpeech;

namespace Tests
{
    [TestClass]
    public class TextToSpeechTests
    {
        [TestMethod]
        public void TestPowerPointScraper()
        {
            // Arrange
            PowerPointScraper scraper = new PowerPointScraper();
            string filePath = @"path\to\your\powerpoint.pptx";

            // Act
            var extractedText = scraper.ExtractTextFromPresentation(filePath);

            // Assert
            Assert.IsNotNull(extractedText);
            Assert.IsTrue(extractedText.Count > 0);
        }

        [TestMethod]
        public void TestTextToSpeechConversion()
        {
            // Arrange
            TextToSpeechConverter tts = new TextToSpeechConverter();
            string text = "Hello, this is a test.";

            // Act
            var result = tts.ConvertTextToSpeech(text);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }
    }
}
