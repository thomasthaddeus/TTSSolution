using System.Collections.Generic;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;

namespace PptxScraper
{
    public class PowerPointScraper
    {
        public IList<string> ExtractTextFromPresentation(string filePath)
        {
            var textList = new List<string>();

            using (PresentationDocument presentationDocument = PresentationDocument.Open(filePath, false))
            {
                PresentationPart presentationPart = presentationDocument.PresentationPart;

                if (presentationPart != null)
                {
                    foreach (SlideId slideId in presentationPart.Presentation.SlideIdList)
                    {
                        SlidePart slidePart = (SlidePart)presentationPart.GetPartById(slideId.RelationshipId);
                        if (slidePart != null)
                        {
                            foreach (var shape in slidePart.Slide.Descendants<Shape>())
                            {
                                if (shape.TextBody != null)
                                {
                                    foreach (var paragraph in shape.TextBody.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())
                                    {
                                        string text = paragraph.InnerText;
                                        if (!string.IsNullOrWhiteSpace(text))
                                        {
                                            textList.Add(text);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return textList;
        }
    }
}
