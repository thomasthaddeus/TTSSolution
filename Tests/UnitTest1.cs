// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitTest1.cs" company="Thaddeus Thomas" TextToSpeechTests>
// Author:      Thaddeus Thomas
// Date:        20230327
// Project:     TextToSpeech
// Solution:    TTS-Solution
// Notes:       Make sure to change the file path for the powerpoint file being tested
// 
// </copyright>
// <summary>
//   The text to speech tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Tests
{
    using PptxScraper;
    using TextToSpeech;

    /// <summary>
    /// The text to speech tests.
    /// </summary>
    [TestClass]
    public class TextToSpeechTests
    {
        /// <summary>
        /// The test power point scraper.
        /// </summary>
        [TestMethod]
        public void TestPowerPointScraper()
        {
            // Change the file path to an actual file
            // Arrange
            var scraper = new PowerPointScraper();
            string filePath = @"path\to\your\powerpoint.pptx";

            // Act
            var extractedText = PowerPointScraper.ExtractTextFromPresentation(filePath);

            // Assert
            Assert.IsNotNull(extractedText);
            Assert.IsTrue(extractedText.Count > 0);
        }

        [TestMethod]
        public void TestTextToSpeech()
        {

        }
    }
}
