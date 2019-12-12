using E14_440FileViewer.NET.dao.implements;
using E14_440FileViewer.NET.interfaces;
using E14_440FileViewer.NET.viewcontroller.utils;
using org.tyaa.e14_440fileviewernet.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E14_440FileViewer.NET.dao
{
    class DataFileFacade : IDataFilesDAO
    {
        //делегат вызова метода получения данных
        private delegate ChannelsBundle GetChannelsBoundle();
        //поле для экземпляра делегата
        private GetChannelsBoundle getChannelsBoundleDelegate;
        //экземпляр датааксессора для новых файлов
        private NewDataFileDAO mNewDataFileDAO;
        //экземпляр датааксессора для старых файлов
        private OldDataFileDAO mOldDataFileDAO;

        private DataFileTypes mDataFileType;

        public DataFileFacade(DataFileTypes _dataFileType)
        {
            mDataFileType = _dataFileType;
            mNewDataFileDAO = new NewDataFileDAO();
            mOldDataFileDAO = new OldDataFileDAO();
            //getChannelsBoundleDelegate =
            //    new GetChannelsBoundle(mNewDataFileDAO.getChannels);
            setDAOType(mDataFileType);
        }

        public ChannelsBundle getChannels()
        {

            return getChannelsBoundleDelegate();
        }

        public void setDAOType(DataFileTypes _dataFileType)
        {
            mDataFileType = _dataFileType;
            switch (mDataFileType)
            {
                case DataFileTypes.NewDataFile:
                    {
                        getChannelsBoundleDelegate =
                            new GetChannelsBoundle(mNewDataFileDAO.getChannels);
                        break;
                    }
                case DataFileTypes.OldDataFile:
                    {
                        getChannelsBoundleDelegate =
                            new GetChannelsBoundle(mOldDataFileDAO.getChannels);
                        break;
                    }
            }
        }


        public Channel getChannel(int _number)
        {
            throw new NotImplementedException();
        }

        public void persistChannels(ChannelsBundle _сhannelsBoundle)
        {
            throw new NotImplementedException();
        }
    }
}
