using System;
using System.Collections.Generic;
using System.IO;

namespace Additional_Libraries_Sitemap_Creator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Yo must create a program to show on screen the contents of a preliminary "sitemap", 
            //taken from the list of ".html" files in the current directory, with "weekly" 
            //    frequence and the current date as "last modification" date.

            List<string> ListHtml = GetHtml();

            CreateSiteMap(ListHtml, "weekly", DateTime.Now);
        }

        static List<string> GetHtml()
        {
            List<string> ListHtml = new List<string>();

            string[] files = Directory.GetFiles(".");

            foreach (string file in files)
            {
                string extension = Path.GetExtension(file);

                switch (extension)
                {
                    case ".html":
                    case ".htm":
                        ListHtml.Add(file.Substring(2));
                        break;
                }
            }

            return ListHtml;
        }


        static void CreateSiteMap(List<string> listHtml, string frecuency, DateTime lastUpdated)
        {
            try
            {
                StreamWriter writer = new StreamWriter(File.Create("sitemap.xml"));

                writer.WriteLine("");
                writer.WriteLine("");

                foreach (string html in listHtml)
                {
                    writer.WriteLine("");
                    writer.WriteLine("" + html + "");
                    writer.WriteLine("" + lastUpdated.ToShortDateString() + "");
                    writer.WriteLine("" + frecuency + "");
                    writer.WriteLine("");
                }

                writer.WriteLine("");

                writer.Close();
            }
            catch
            {
                Console.WriteLine("Error writing sitemap.");
            }
        }
    }
}
