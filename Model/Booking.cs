using System;
namespace HMS.Model
{
    public class Booking
    {
        public int Id {get; set;}
        public DateTime BookingDate {get; set;}
        public DateTime CheckInDate {get; set;}
        public DateTime CheckOutDate {get; set;}
        public bool isChecked {get; set;}
        public bool isAvailable {get; set;}
        public int RoomType {get; set;}
        public int Duration {get; set;}

        public Booking (int id, DateTime bookingDate, DateTime checkInDate, DateTime checkOutDate, bool ischecked, bool isavailable, int roomType, int duration)
        {
            Id = id;
            BookingDate = bookingDate;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            isChecked = ischecked;
            isAvailable = isavailable;
            RoomType = roomType;
            Duration = duration;
        }

        public string ConvertToFileFormat()
        {
            return $"{Id}+++{BookingDate}+++{CheckInDate}+++{CheckOutDate}+++{isChecked}+++{isAvailable}+++{RoomType}+++{Duration}";
        }

         public static Booking ConvertToBooking(string bookinginfo)
        {
            string[] info = bookinginfo.Split("+++");
            return new Booking(int.Parse(info[0]),DateTime.Parse(info[1]),DateTime.Parse(info[2]),DateTime.Parse(info[3]),bool.Parse(info[4]),bool.Parse(info[5]),int.Parse(info[6]),int.Parse(info[7]));
        }
    }
}