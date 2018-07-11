using org.tyaa.e14_440fileviewernet.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace E14_440FileViewer.NET.utils
{
    class ImportXML
    {
        private ChannelsBoundle mChannelsBoundle;
        private int mFrequency;
        private int mChannelsCount;
        //Порядковые номера каналов
        private int[] mNumbersArray;
        //Коды коэффициентов усиления каналов
        private int[] mAmpsArray;

        private ArrayList mChannelArrayList;

        //файл схемы
        private const String SCEMA_URI_STRING = "ChannelsMetadata.xsd";

        public ChannelsBoundle getChannelsMetadata(String _path)
        {

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(_path);

            if (validateChannelsMetadataXML(xmlDocument))
            {
                mFrequency = Int32.Parse(xmlDocument.GetElementsByTagName("frequency")[0].InnerText);
                //Console.WriteLine(mFrequency);

                XmlNode channelsNode = xmlDocument.GetElementsByTagName("channels")[0];

                if (channelsNode.HasChildNodes)
                {
                    mChannelsCount = channelsNode.ChildNodes.Count;
                    //Console.WriteLine(mChannelsCount);

                    mNumbersArray = new int[mChannelsCount];
                    mAmpsArray = new int[mChannelsCount];
                    mChannelArrayList = new ArrayList(mChannelsCount);

                    int channelNodeIdx = 0;
                    foreach (XmlNode channelNode in channelsNode)
                    {
                        mNumbersArray[channelNodeIdx] = Int32.Parse(channelNode.Attributes["number"].InnerText);
                        mAmpsArray[channelNodeIdx] = Int32.Parse(channelNode.ChildNodes[0].InnerText);
                        mChannelArrayList.Add(new Channel(mNumbersArray[channelNodeIdx], mAmpsArray[channelNodeIdx]));
                        channelNodeIdx++;
                    }
                }

                mChannelsBoundle = new ChannelsBoundle(mNumbersArray, mAmpsArray, mFrequency);
                mChannelsBoundle.channelArrayList = mChannelArrayList;

                return mChannelsBoundle;
            }
            else
            {
                throw new Exception("Inavid xml document!");
            }

            
        }

        private bool validateChannelsMetadataXML(XmlDocument _xmlDocument)
        {

            //
            bool valid = true;

            //
            XDocument xDocument = XDocument.Parse(_xmlDocument.OuterXml);

            //создали объект XmlSchemaSet для приема содержимого файла схемы xsd 
            XmlSchemaSet schemas = new XmlSchemaSet();
            //загрузили файл xsd
            schemas.Add("", SCEMA_URI_STRING);

            //валидация входного xml по схеме xsd
            Console.WriteLine("Validating xdocument ...");

            xDocument.Validate(schemas, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                valid = false;
            });

            return valid;
        }
    }
}
