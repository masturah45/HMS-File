using System;
using HMS.Model;

namespace HMS.Interfaces
{
    public interface IBookingManager
    {
        public Booking GetBooking (int id, DateTime bookingDate);
        public void UpdateBooking ();
        public void DeleteBooking ();
        public Booking GetBooking (DateTime bookingDate);
        public void GetAllBooking ();
        public void CreateBooking (Customer customer, DateTime bookingDate, DateTime checkInDate, DateTime checkOutDate, string roomId, bool isavailable, int roomtype, int duration);
        public Booking GetAvailableRooms(int roomType, DateTime bookingDate, int duration );
        public void ReadFromFile();
        public void ReWriteFile();
    }
}
