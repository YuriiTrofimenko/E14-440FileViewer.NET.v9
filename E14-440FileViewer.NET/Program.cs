using E14_440FileViewer.NET.dao;
using E14_440FileViewer.NET.model.interfaces;
using E14_440FileViewer.NET.viewcontroller.utils;
// using Moq;
using org.tyaa.e14_440fileviewernet.model;
using gen = org.tyaa.e14_440fileviewernet.model.generics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using E14_440FileViewer.NET.utils;
using E14_440FileViewer.NET.dao.implements.NewDataFileDAO_Parts;
using System.Threading;
using E14_440FileViewer.NET;
using System.Windows.Forms;
using E14_440FileViewer.NET.forms;

namespace org.tyaa.e14_440fileviewernet
{
    public class Program
    {
        //private delegate void WorkDelegate(string fileName);
        public static int start2;
        public static int threadCount = 3;
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            /*ChannelsBundle channelsBundle1 =
                new ChannelsBundle(new int[]{ 1, 2, 3 }, new int[] { 1, 1, 1 }, 1500);
            channelsBundle1[0] = new Channel();
            channelsBundle1[1] = new Channel();
            channelsBundle1[50] = new Channel();
            channelsBundle1[40] = new Channel();
            Console.WriteLine(channelsBundle1[50]);
            Console.WriteLine(channelsBundle1[40]);*/
            //Channel channel1 = new Channel(1, 0);
            //Channel channel2 = new Channel(2, 0);

            //channel1.addDataItem(0);
            //channel1.addDataItem(1.01);
            //channel1.addDataItem(1.02);
            //channel1.addDataItem(1.03);

            //foreach (double dataItem in channel1.getDataArray())
            //{
            //    Console.WriteLine(dataItem);
            //}

            //ChannelsBoundle channelsBoundle1 = new ChannelsBoundle(null, null, 1500);

            //channel2.addDataItem(0.001);
            //channel2.addDataItem(1.015);
            //channel2.addDataItem(1.025);
            //channel2.addDataItem(1.035);

            //channelsBoundle1[0] = channel1;
            //channelsBoundle1[1] = channel2;

            //foreach (Channel channel in channelsBoundle1)
            //{
            //    foreach (double dataItem in channel.getDataArray())
            //    {
            //        Console.WriteLine(dataItem);
            //    }
            //}

            // Filters filters1 = Filters.Batterwort;
            // Filters filters2 = Filters.Chebishev;
            //Console.WriteLine(filters1 < filters2);

            /*DataFileFacade2 dataFileFacade
                = new DataFileFacade2(DataFileTypes.OldDataFile);
            dataFileFacade.getChannels();
            dataFileFacade.setDAOType(DataFileTypes.NewDataFile);
            dataFileFacade.getChannels();*/
            /*dataFileFacade.setDAOType(DataFileTypes.NewDataFile);
            dataFileFacade.getChannels();
            dataFileFacade.setDAOType(DataFileTypes.OldDataFile);
            dataFileFacade.getChannels();*/

            /*IChannelsBundle> mock = new Mock<IChannelsBundle>();
            mock.Setup(m => m.channelArrayList).Returns(
                new ArrayList{
                    //new Channel{dataArray = new double?[3]{1, 2, 3}}
                    //,new Channel{dataArray = new double?[3]{0, 1, 2}}
                    new Channel{dataArrayList = (new ArrayList(){1d, 2d, 3d})}
                    ,new Channel{dataArrayList = new ArrayList(){0d, 1d, 2d}}
                }
            );
            foreach (Channel channel in mock.Object.channelArrayList)
            {
                foreach (double dataItem in channel.getDataArray())
                {
                    Console.Write(dataItem + " ");
                }
                Console.WriteLine();
            }*/

            /*const Int32 count = 10000000;

            using (new OperationProfiler("Channel<T>"))
            {
                gen.Channel<double> channel1 = new gen.Channel<double>(1, 0);
                for (Int32 n = 0; n < count; n++)
                {
                    channel1.addDataItem(n);
                }
                channel1 = null;  // для гарантированного выполнения сборки мусора
            }*/

            //using (new OperationProfiler("Channel"))
            //{
            //    Channel channel1 = new Channel(1, 0);
            //    for (Int32 n = 0; n < count; n++)
            //    {
            //        channel1.addDataItem(n);
            //    }
            //}

            //gen.Channel<double> channel1 = new gen.Channel<double>(1, 0);


            //Channel channel2 = new Channel();
            //channel2 = null;

            /*Чтение бинарных файлов*/

            /* String filePath = @"C:\Users\student\Source\Repos\E14-440FileViewer.NET.v9\data\10f";

            ParamsReader paramsReader = new ParamsReader();
            List<gen.Channel<double>> channelsArrayList =
                paramsReader.getParams(filePath + ".prm");
            Console.WriteLine(paramsReader.Count + " " + paramsReader.Frequency + "\n");
            foreach (gen.Channel<double> channel in channelsArrayList)
            {
                Console.WriteLine(channel.number + " " + channel.amp);
            }

            DataReader dataReader = new DataReader();
            dataReader.getData(@"C:\Users\student\Source\Repos\E14-440FileViewer.NET.v9\data\10f" + ".dat", ref channelsArrayList);
            *//*foreach (double dataItem in channelsArrayList[1].getDataArray())
            {
                //Console.WriteLine(dataItem);
            }*/

            /*List<double> channelsMax = new List<double>();
            foreach (var channel in channelsArrayList)
            {
                //channelsMax.Add(getMax(item.getDataArray()));
                //channelsMax.Add(item.getDataArray().Max());
                Console.WriteLine(channel.getDataArray().Max());
            }*/
            //Console.WriteLine(getMax(channelsMax));

            // WorkHelper workHelper = new WorkHelper();

            /*int start1 = DateTime.Now.Millisecond;
            workHelper.printMax(@"C:\Users\student\tyaa\C#\SystemDev\сп\16 02 2013 9-10");
            workHelper.printMax(@"C:\Users\student\tyaa\C#\SystemDev\сп\16 02 2013 9-00 tar");
            workHelper.printMax(@"C:\Users\student\tyaa\C#\SystemDev\сп\10f");
            Console.WriteLine(DateTime.Now.Millisecond - start1);
            //1.6 1.7 1.4*/

            //start2 = DateTime.Now.Millisecond;
            /* workHelper.doThread(
                workHelper.printMax
                , @"C:\Users\student\source\repos\SP\e440cs-v9\data\10f"
            ); */
            /*workHelper.doThread(
                workHelper.printMax
                , @"C:\Users\student\tyaa\C#\SystemDev\сп\16 02 2013 9-00 tar"
            );
            workHelper.doThread(
                workHelper.printMax
                , @"C:\Users\student\tyaa\C#\SystemDev\сп\10f"
            );*/

            /*ThreadPool.QueueUserWorkItem(workHelper.printMax
                , @"C:\Users\student\tyaa\C#\SystemDev\сп\16 02 2013 9-10");
            ThreadPool.QueueUserWorkItem(workHelper.printMax
                , @"C:\Users\student\tyaa\C#\SystemDev\сп\16 02 2013 9-00 tar");
            ThreadPool.QueueUserWorkItem(workHelper.printMax
                , @"C:\Users\student\tyaa\C#\SystemDev\сп\10f");


            Thread.Sleep(1000);*/

            /*while (true)
            {
                if (threadCount == 0)
                {
                    Console.WriteLine(DateTime.Now.Millisecond - start2);
                    break;
                }
            }*/

            /*Запись метаданных в XML-файл*/

            /*Channel channel1 = new Channel(1, 0);
            Channel channel2 = new Channel(2, 0);

            channel1.addDataItem(0);
            channel1.addDataItem(1.01);
            channel1.addDataItem(1.02);
            channel1.addDataItem(1.03);

            int[] numbersArray = new int[] { channel1.number, channel2.number};
            int[] ampsArray = new int[] { channel1.amp, channel2.amp };

            ChannelsBoundle channelsBoundle1 = new ChannelsBoundle(numbersArray, ampsArray, 1500);

            channel2.addDataItem(0.001);
            channel2.addDataItem(1.015);
            channel2.addDataItem(1.025);
            channel2.addDataItem(1.035);

            channelsBoundle1[0] = channel1;
            channelsBoundle1[1] = channel2;

            ExportXML exportXML = new ExportXML();
            exportXML.saveChannelsMetadata(ref channelsBoundle1, ReportTypes.HTML);*/

            /*ImportXML importXML = new ImportXML();
            ChannelsBoundle channelsBoundle2 =
                importXML.getChannelsMetadata(@"ChannelsMetadata.xml");

            Console.WriteLine("frequency = {0}", channelsBoundle2.frequency);

            foreach (Channel channel in channelsBoundle2)
            {
                Console.WriteLine("number = {0}; amplification = {1}", channel.number, channel.amp);
            }

            Console.ReadLine();*/


            /*Чтение бинарных файлов C++*/

            /*String filePath = @"D:/Temp/10f";

            ParamsReader paramsReader = new ParamsReader();
            List<gen.Channel<double>> channelsArrayList =
                paramsReader.getParams(filePath + ".prm");
            Console.WriteLine(paramsReader.Count + " " + paramsReader.Frequency + "\n");
            foreach (gen.Channel<double> channel in channelsArrayList)
            {
                Console.WriteLine(channel.number + " " + channel.amp);
            }*/
        }

        /*private void doThread(Program.WorkDelegate workDelegate, string _fileName) {

            new Thread((_fileName) => workDelegate()).Start();
        }*/
    }
}
