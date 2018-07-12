using E14_440FileViewer.NET.dao.implements.NewDataFileDAO_Parts;
using org.tyaa.e14_440fileviewernet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using gen = org.tyaa.e14_440fileviewernet.model.generics;

namespace E14_440FileViewer.NET.utils
{
    public class WorkHelper : IWork
    {
        /*public void doThread(IWork workFunction, Object _fileName)
        {
            
        }*/

        private static double getMax(List<double> list)
        {
            double max = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] > max)
                {
                    max = list[i];
                }
            }
            return max;
        }

        public void printMax(Object _fileName)
        {
            //Interlocked.Increment(ref Program.threadCount);
            //Program.threadCount++;
            String filePath = _fileName.ToString();

            ParamsReader paramsReader = new ParamsReader();
            List<gen.Channel<double>> channelsArrayList =
                paramsReader.getParams(filePath + ".prm");
            //Console.WriteLine(paramsReader.Count + " " + paramsReader.Frequency + "\n");
            /*foreach (gen.Channel<double> channel in channelsArrayList)
            {
                Console.WriteLine(channel.number + " " + channel.amp);
            }*/

            DataReader dataReader = new DataReader();
            dataReader.getData(_fileName + ".dat", ref channelsArrayList);
            //foreach (double dataItem in channelsArrayList[1].getDataArray())
            //{
            //Console.WriteLine(dataItem);
            //}

            List<double> channelsMax = new List<double>();
            foreach (var item in channelsArrayList)
            {
                channelsMax.Add(getMax(item.getDataArray()));
                //Console.WriteLine(getMax(item.getDataArray()));
            }
            Console.WriteLine(getMax(channelsMax));
            //Program.threadCount--;
            Interlocked.Decrement(ref Program.threadCount);

            if (Program.threadCount == 0)
            {
                Console.WriteLine(DateTime.Now.Millisecond - Program.start2);
            }
        }

        internal void doThread(Action<object> workFunction, string _fileName)
        {
            new Thread(
                new ParameterizedThreadStart(workFunction)
            ).Start(_fileName);
        }
    }
}
