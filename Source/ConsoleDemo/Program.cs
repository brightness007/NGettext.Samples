using NGettext;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            List<Tuple<string, ICatalog>> catalogs = new List<Tuple<string, ICatalog>>
            {
                new Tuple<string, ICatalog>("default", new Catalog("Demo", @".\Locales")),
                new Tuple<string, ICatalog>("en-US", new Catalog("Demo", @".\Locales", new CultureInfo("en-US"))),
                new Tuple<string, ICatalog>("zh-CN", new Catalog("Demo", @".\Locales", new CultureInfo("zh-CN"))),
            };

            foreach(var catalog in catalogs)
            {
                Console.WriteLine("Locale: {0}", catalog.Item1);
                DemoMessages msg = new DemoMessages(catalog.Item2);

                Console.WriteLine(msg.HELLO_WORLD());
                Console.WriteLine(msg.APPLE_COUNT_MESAGE(1));
                Console.WriteLine(msg.APPLE_COUNT_MESAGE(2));
                Console.WriteLine(msg.TREE_COUNT_MESAGE(1));    // Not Translated, Fallback to English
                Console.WriteLine(msg.TREE_COUNT_MESAGE(2));    // Not Translated, Fallback to English

                Console.WriteLine();
            }

            Console.WriteLine("Locale: (Stream)");
            using (var stream = new FileStream(@".\Locales\zh_CN\LC_MESSAGES\Demo.mo", FileMode.Open, FileAccess.Read))
            {
                ICatalog catalog = new Catalog(stream, new CultureInfo("zh-CN"));
                DemoMessages msg = new DemoMessages(catalog);
                Console.WriteLine(msg.APPLE_COUNT_MESAGE(2));
            }
        }
    }
}
