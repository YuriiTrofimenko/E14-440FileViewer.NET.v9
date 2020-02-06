using E14_440FileViewer.NET.dao.implements.NewDataFileDAO_Parts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gen = org.tyaa.e14_440fileviewernet.model.generics;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Resources;
using System.Globalization;
using E14_440FileViewerNET.model;

namespace E14_440FileViewer.NET.forms
{
    public partial class MainForm : Form
    {
        private PointF startPoint = new PointF();
        List<gen.Channel<double>> channelsArrayList;
        private string[] langList;
        private string currentLang = "en";
        private bool localization = false;

        private IEnumerable<Color> GetColor() {
            yield return Color.Red;
            yield return Color.Green;
            yield return Color.Yellow;
            yield return Color.Blue;
            yield return Color.Black;
            yield return Color.Gray;
            yield return Color.Brown;
            yield return Color.Orange;
        }

        private IEnumerable<string> GetLang()
        {
            yield return "en";
            yield return "ru";
        }

        public MainForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            startPoint.X = 0;
            langList = new string[]{ "en", "ru" };
            langToolStripComboBox1.Items.AddRange(langList);
            ChangeLang(currentLang);
            langToolStripComboBox1.SelectedIndex = 0;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "E14-440 Data (*.dat)|*.dat";
            if (open.ShowDialog() == DialogResult.OK)
            {
                String filePath = open.FileName.Replace(".dat", "");

                Console.WriteLine(filePath);

                ParamsReader paramsReader = new ParamsReader();
                channelsArrayList =
                    paramsReader.getParams(filePath + ".prm");

                DataReader dataReader = new DataReader();
                dataReader.getData(filePath + ".dat", ref channelsArrayList);

                foreach (var channel in channelsArrayList)
                {
                    Console.WriteLine(channel.getDataArray().Max());
                }

                this.Refresh();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine(e.Graphics);
            if (channelsArrayList != null && channelsArrayList.Count > 0)
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.HighQuality;
                double zoomX = 1.0;
                startPoint.Y = e.ClipRectangle.Height / 2;
                double drawStep =
                    (double)this.Width / (double)channelsArrayList[0].dataArrayList.Count * zoomX;
                Console.WriteLine(drawStep);
                PointF currentLineStart;
                IEnumerable<Color> colors = GetColor();
                int counter = 0;
                foreach (var channel in channelsArrayList)
                {
                    currentLineStart = startPoint;
                    Color color = colors.ElementAt(counter++);
                    foreach (var item in channel.dataArrayList)
                    {
                        g.DrawLine(
                            new Pen(color),
                            currentLineStart,
                            new PointF((float)(currentLineStart.X), (float)((startPoint.Y - (float)(item * 100.0))))
                        );
                        currentLineStart.X += (float)drawStep;
                        currentLineStart.Y = startPoint.Y - (float)(item * 100.0);
                    }
                }
            }
        }

        private void langToolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!localization)
            {
                IEnumerable<string> langs = GetLang();
                currentLang =
                    langs.ElementAt(((ToolStripComboBox)sender).SelectedIndex);
                ChangeLang(currentLang);
            }
        }

        private void ChangeLang(string lang) {
            localization = true;
            ResourceManager manager =
                new ResourceManager(@"E14_440FileViewerNET.lang_resources.messages", typeof(MainForm).Assembly);
            CultureInfo ci = new CultureInfo(lang);
            fileToolStripMenuItem.Text = manager.GetString("file", ci);
            openToolStripMenuItem.Text = manager.GetString("open", ci);

            IEnumerable<string> langs = GetLang();
            for (int langCounter = 0; langCounter < langs.Count(); langCounter++)
            {
                langToolStripComboBox1.Items[langCounter] =
                    manager.GetString(langs.ElementAt(langCounter), ci);
            }
            localization = false;
        }
    }
}
