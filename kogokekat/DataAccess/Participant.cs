using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kogokekat.DataAccess
{
    public class Participant : IComparable<Participant>
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Token { get; set; }
        public int Rating { get; set; }
        public int Id { get; set; }

        public bool IsVoted { get; set; }
        public Participant(int id, String firstname, String lastname, String token)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Token = token;
            Rating = 0;
            IsVoted = true;
        }

        public int CompareTo(Participant other)
        {
            if (other == null)
                throw new Exception();

            if (other.Rating > this.Rating)
                return 1;

            if (other.Rating < this.Rating)
                return -1;

            if (other.Rating == this.Rating)
                return 0;

            return 0;
        }
    }
}