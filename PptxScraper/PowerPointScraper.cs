// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PowerPointScraper.cs" company="ThadsSoftwareDesigns" author="Thaddeus Thomas">
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
    using System.Collections.Generic;
    using System.Linq;

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
        /// The <see cref="IList{T}"/>.
        /// </returns>
        public static IList<string> ExtractTextFromPresentation(string filePath)
        {
            var textList = new List<string>();

            using var presentationDocument = PresentationDocument.Open(filePath, false);
            var presentationPart = presentationDocument?.PresentationPart;

            if (presentationPart == null) return textList;

            var slideIds = presentationPart.Presentation?.SlideIdList?.OfType<SlideId>();

            if (slideIds == null) return textList;

            foreach (var slideId in slideIds)
            {
                string? relationshipId = slideId.RelationshipId;

                if (string.IsNullOrEmpty(relationshipId)) continue;

                OpenXmlPart? slidePart = presentationPart.GetPartById(relationshipId);
                if (slidePart is not SlidePart sp || sp.Slide == null) continue;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                textList.AddRange(from shape in sp.Slide.Descendants<Shape>()
                                  where shape.TextBody != null
                                  from paragraph in shape.TextBody.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>()
                                  select paragraph.InnerText into text
                                  where !string.IsNullOrWhiteSpace(text)
                                  select text);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }

            return textList;
        }
    }
}