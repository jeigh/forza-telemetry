using System.Text;

namespace ForzaCore.DataAccessLayer
{
    public interface IDataAccessLayer
    {
        void RecordData(DataPacket data);
        
        string CurrentFileName { get; set; }

        void WriteHeader(StringBuilder sb);
    }
}
