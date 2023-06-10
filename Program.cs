using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace NiceUIDesign
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            /*Dictionary<string, int> new_dict = new Dictionary<string, int>();
            new_dict.Add("Hello", 1);
            new_dict.Add("Hello2", 2);
            new_dict.Add("Hello3", 3);

            string json = JsonConvert.SerializeObject(new_dict, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("dictionary.json", json);*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
