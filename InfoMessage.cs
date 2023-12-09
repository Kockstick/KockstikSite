namespace KockstikSite
{
    public class InfoMessage
    {
        public bool IsShow { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }

        public InfoMessage(string title, string text)
        {
            Title = title;
            Text = text;
            Type = "normal";
        }

        public InfoMessage(string title, string text, string type)
        {
            Title = title;
            Text = text;
            Type = type;
        }
    }
}
