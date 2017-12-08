using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using MVC.Models;

namespace MVC
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public String[] ReadFile()
        {
            var s = new List<String>();
            using (StreamReader sr = new StreamReader(@"C:/Programs/C#/MVC/books.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    s.Add(line);
                }
                sr.Close();
            }
            return s.ToArray();
        }

        [WebMethod]
        public void WriteFile(List<String> books)
        {
            using (StreamWriter sw = new StreamWriter(@"C:/Programs/C#/MVC/books.txt"))
            {
                foreach (String b in books)
                {
                    sw.WriteLine(b);
                }
                sw.Close();
            }
        }
    }
}
