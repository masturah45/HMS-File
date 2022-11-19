namespace HMS.Model
{
    public class Room
    {
        public int Id {get; set;}
        public string Type {get; set;}
        public double Price {get; set;}
        public string RoomNumber {get; set;}

        public Room (int id, string type, double price, string roomNumber)
        {
            Id = id;
            Type = type;
            Price = price;
            RoomNumber = roomNumber;
        }

        public string ConvertToFileFormat()
        {
            return $"{Id}+++{Type}+++{Price}+++{RoomNumber}"; 
        }

         public static Room ConvertToRoom(string roominfo)
        {
            string[] info = roominfo.Split("+++");
            return new Room(int.Parse(info[0]),info[1],double.Parse(info[2]),info[3]);
        }
    }
}