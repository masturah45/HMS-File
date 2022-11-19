using HMS.Model;

namespace HMS.Interfaces
{
    public interface IRoomManager
    {
        public void CreateRoom (string type, double price);
        public void UpdateRoom ();
        public void DeleteRoom ();
        public Room GetRoom (string type);
        public void GetAllRooms ();
        public void ReadFromFile();
        public void ReWriteFile();
    }
}