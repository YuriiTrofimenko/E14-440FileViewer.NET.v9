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

namespace E14_440FileViewer.NET.forms
{
    public partial class MainForm : Form
    {
        private PointF startPoint = new PointF();
        List<gen.Channel<double>> channelsArrayList;

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

        public MainForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            startPoint.X = 0;
            //startPoint.Y = this.Height;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // this.Close();
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
                /* Console.WriteLine(paramsReader.Count + " " + paramsReader.Frequency + "\n");
                foreach (gen.Channel<double> channel in channelsArrayList)
                {
                    Console.WriteLine(channel.number + " " + channel.amp);
                } */

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
                double zoomY = 2.0;
                startPoint.Y = e.ClipRectangle.Height / 2;
                double drawStep =
                // (double)channelsArrayList[0].dataArrayList.Count*(1.0f / this.Width);
                    (double)this.Width / (double)channelsArrayList[0].dataArrayList.Count * zoomX;
                Console.WriteLine(drawStep);
                PointF currentLineStart;
                //var currentLineStart = startPoint;
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
                        // Console.WriteLine(currentLineStart);
                        //currentDoubleX += drawStep;
                        currentLineStart.X += (float)drawStep;
                        currentLineStart.Y = startPoint.Y - (float)(item * 100.0);
                    }
                }
            }
            
            // g.DrawEllipse(new Pen(Color.BlueViolet), 100, 100, 200, 300);
            // g.DrawLine(new Pen(Color.Red), startPoint, new Point(50, startPoint.Y - 300));
        }
    }
}
