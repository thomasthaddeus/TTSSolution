namespace DataModels
{
    public class Slide
    {
        public int SlideNumber { get; set; }
        public string SlideTitle { get; set; }
        public string SlideContent { get; set; }
        public string Notes { get; set; }

        public Slide(int slideNumber, string slideTitle, string slideContent, string notes)
        {
            SlideNumber = slideNumber;
            SlideTitle = slideTitle;
            SlideContent = slideContent;
            Notes = notes;
        }
    }
}
