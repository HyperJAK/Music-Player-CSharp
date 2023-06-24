using System;
using System.Diagnostics;
using System.Windows.Forms;

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
            Process currentProcess = Process.GetCurrentProcess();
            currentProcess.PriorityClass = ProcessPriorityClass.High;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
