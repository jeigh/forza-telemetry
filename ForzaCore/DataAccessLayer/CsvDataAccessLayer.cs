using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static ForzaCore.Program;

namespace ForzaCore.DataAccessLayer
{


    public class CsvDataAccessLayer : IDataAccessLayer
    {
        //private string _currentFilename = "./data/" + DateTime.Now.ToFileTime() + ".csv";
        public string CurrentFileName { get; set; } = "./data/" + DateTime.Now.ToFileTime() + ".csv";

        public void WriteHeader(StringBuilder sb)
        {
            StreamWriter sw = new StreamWriter(CurrentFileName, true, Encoding.UTF8);
            sw.WriteLine(sb.ToString());
            sw.Close();
        }

        public void RecordData(DataPacket data)
        {
            string dataToWrite = DataPacketToCsvString(data);
            const int BufferSize = 65536;  // 64 Kilobytes
            StreamWriter sw = new StreamWriter(CurrentFileName, true, Encoding.UTF8, BufferSize);
            sw.WriteLine(dataToWrite);
            sw.Close();
        }

        private string DataPacketToCsvString(DataPacket packet)
        {
            IEnumerable<object> values = packet.GetType()
                 .GetProperties()
                 .Where(p => p.CanRead)
                 .Select(p => p.GetValue(packet, null));

            StringBuilder sb = new StringBuilder();
            sb.AppendJoin(',', values);
            return sb.ToString();
        }

        //public string GetCurrentFilename()
        //{
        //    return _currentFilename;
        //}

        //public void SetCurrentFilename(string relativeFileName)
        //{
        //    _currentFilename = relativeFileName;
        //}
    }
}
