using E14_440FileViewer.NET.dao.implements;
using E14_440FileViewer.NET.interfaces;
using E14_440FileViewer.NET.viewcontroller.utils;
using org.tyaa.e14_440fileviewernet.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace E14_440FileViewer.NET.dao
{
    class DataFileFacade2 : IDataFilesDAO
    {
        //экземпляр датааксессора для новых файлов
        private NewDataFileDAO mNewDataFileDAO;
        //экземпляр датааксессора для старых файлов
        private OldDataFileDAO mOldDataFileDAO;

        private DataFileTypes mDataFileType;

        public DataFileFacade2(DataFileTypes _dataFileType)
        {
            setDAOType(_dataFileType);
            // mNewDataFileDAO = new NewDataFileDAO();
            // mOldDataFileDAO = new OldDataFileDAO();
        }

        public ChannelsBundle getChannels()
        {
            return ((IDataFilesDAO)Type.GetType($"E14_440FileViewer.NET.dao.implements.{mDataFileType.ToString()}DAO")
                .GetConstructor(Type.EmptyTypes)
                .Invoke(null)
                ).getChannels();
        }

        public void setDAOType(DataFileTypes _dataFileType)
        {
            mDataFileType = _dataFileType;
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
