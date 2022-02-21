using System;
using Exercicio_15.Entites.Exceptions;
namespace Exercicio_15.Entites
{
    class Reservation
    {
        private int _roomNumber { get; set; }
        private DateTime _checkIn { get; set; }
        private DateTime _checkOut { get; set; }

        public Reservation()
        {
        }

        public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut)
        {
            if (checkOut <= checkIn)
            {
                throw new DomainException("check-out date must be after check-in date.");
            }
            _roomNumber = roomNumber;
            _checkIn = checkIn;
            _checkOut = checkOut;
        }

        public int duration()
        {
            TimeSpan duration = _checkOut.Subtract(_checkIn);
            return (int)duration.TotalDays;
        }
        public void updateDates(DateTime checkIn, DateTime checkOut)
        {
            DateTime now = DateTime.Now;
            if (checkIn < now || checkOut < now)
            {
                throw new DomainException("reservation date for update must be future dates.");
            }
            if (checkOut <= checkIn)
            {
                throw new DomainException("check-out date must be after check-in date.");
            }
            _checkIn = checkIn;
            _checkOut = checkOut;
        }
        public override string ToString()
        {
            return "Room "
                + _roomNumber
                + ", check-in: "
                + _checkIn.ToString("dd/MM/yyyy")
                + ", check-out: "
                + _checkOut.ToString("dd/MM/yyyy")
                + ", "
                +duration()
                + " nights";
        }
    }
}
