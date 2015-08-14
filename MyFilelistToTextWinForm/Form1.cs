using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MyFilelistToTextWinForm
{
    public partial class Form1 : Form
    {
        private static readonly string path = @"w:\Videos\Movies\";
        private static readonly string pathToWriteTo = @"c:\opt\mymovies.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // string[] files = Directory.GetFiles(path); - works

            // comm var files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);

            List<string> files;
            int filecount;
            DateTime start;
            DateTime end;

            GetFileData(out files, out filecount, out start, out end);

            using (var x = File.CreateText(pathToWriteTo))
            {
                foreach (var t in files)
                {
                    x.Write(t + Environment.NewLine);
                }
            }


            lblResult.Text = filecount + @" files found in " + (end - start).TotalSeconds;
        }

        private void GetFileData(out List<string> files, out int filecount, out DateTime start, out DateTime end)
        {
            start = DateTime.Now;

            var temp = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories).ToList();
            temp.Sort();
            files = temp;

            filecount = files.Count();

            end = DateTime.Now;
        }
    }
}