// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PowerPointScraper.cs" company="" author=Thaddeus Thomas>
//   
// Date:        20230327
// Project:     TextToSpeech
// Solution     TTS-Solution
// </copyright>
// <notes></notes>
// <summary>
//   The power point scraper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace PptxScraper
{
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Presentation;

    /// <summary>
    /// The power point scraper.
    /// </summary>
    public class PowerPointScraper
    {
        /// <summary>
        /// The extract text from presentation.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        public IList<string> ExtractTextFromPresentation(string filePath)
        {
            var textList = new List<string>();

            using (PresentationDocument presentationDocument = PresentationDocument.Open(filePath, false))
            {
                PresentationPart presentationPart = presentationDocument.PresentationPart;

                if (presentationPart == null) return textList;
                foreach (SlideId slideId in presentationPart.Presentation.SlideIdList)
                {
                    SlidePart slidePart = (SlidePart)presentationPart.GetPartById(slideId.RelationshipId);
                    if (slidePart == null) continue;
                    textList.AddRange(from shape in slidePart.Slide.Descendants<Shape>() where shape.TextBody != null from paragraph in shape.TextBody.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>() select paragraph.InnerText into text where !string.IsNullOrWhiteSpace(text) select text);
                }
            }

            return textList;
        }
    }
}