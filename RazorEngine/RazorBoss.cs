using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Westwind.RazorHosting;

using System.Threading.Tasks;

namespace Razor
{
    public class RazorBoss
    {
        /// <summary>
        /// This function will be used for getting the HTML of Razor view
        /// </summary>
        /// <param name="fullFilePath"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string GetHtmlFromRazorView(string fullFilePath, object model = null)
        {
            string template = System.IO.File.ReadAllText(fullFilePath);

            var host = new RazorEngine();

            //string curdir = Environment.CurrentDirectory;
            host.AddAssembly("System.Data.dll");
            host.AddAssembly("System.Xml.dll");
            host.AddAssembly("Newtonsoft.Json.dll");
            //host.AddNamespace("Newtonsoft.Json");
            string resultHtml = host.RenderTemplate(template, model);

            // Returning the generated html
            return Convert.ToString(resultHtml);
        }
    }
}
