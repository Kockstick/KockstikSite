using System.Xml;
using System.Xml.Linq;

namespace KockstikSite
{
    public class Courses
    {
        public static List<String> GetCourses()
        {
            var list = new List<string>();
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("https://www.cbr-xml-daily.ru/daily_utf8.xml");
                if (xDoc == null)
                    return list;

                XmlElement xRoot = xDoc.DocumentElement;

                foreach (XmlElement xnode in xRoot)
                {
                    string item = "";
                    foreach (XmlNode child in xnode)
                    {
                        if (child.Name == "Name")
                            item = child.InnerText;
                        if (child.Name == "Value")
                            item += "-" + child.InnerText;
                    }
                    list.Add(item);
                }
            }
            catch { }
            return list;
        }
    }
}
