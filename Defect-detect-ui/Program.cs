using System;
using System.IO;
using System.Windows.Forms;

namespace Defect_detect_ui
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string imageDirectory = projectDirectory + "\\Images";
            string filename = imageDirectory + "\\SV_image_-766126070.bmp";

            MainWindow form = new();

            Application.Run(form);
        }
    }
}