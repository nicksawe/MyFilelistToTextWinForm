using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MyFilelistToTextWinForm
{
    public partial class Form1 : Form
    {                                                               
            static string path = @"w:\Videos\Movies\";                     
            static string pathToWriteTo = @"c:\opt\mymovies.txt";          


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


           // string[] files = Directory.GetFiles(path); - works

          //  List<string> filelist = new List<string>(); - not tested


            // comm var files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);

            IEnumerable<string> files;
            int filecount;
            DateTime start;
            DateTime end;

            GetFileData(out files,out filecount, out start,out end);

          //  var result = files.OrderBy(s => s);//sorted alphabetically ! SO tip

            using (var x = File.CreateText(pathToWriteTo))
            {
                foreach (var t in files)
                {
                    x.Write(t + Environment.NewLine);
                }
            }

            
            lblResult.Text = filecount.ToString() + @" files found in " + (end - start).TotalSeconds;
        }

       

        private void GetFileData(out IEnumerable<string> files, out int filecount, out DateTime start, out DateTime end)
        {
            start = DateTime.Now;

            files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
            filecount = files.Count();

            end = DateTime.Now;
        }


    }
}