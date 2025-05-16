using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //public int PassengerId { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [EmailAddress]
        public String EmailAddress { get; set; }
        public FullName FullName { get; set; }
        [Key]
        [StringLength(7)]
        public String PassportNumber { get; set; }
        [RegularExpression("^[0-9]{8}$")]
        public String TelNumber { get; set; }
        public virtual ICollection<Ticket> ListTickets { get; set; }

        //public ICollection<Flight> Flights { get; set; }

        public override string ToString()
        {
            return " First Name: " + FullName.FirstName
                + " Last Name: " + FullName.LastName;
        }

        //public bool CheckProfile(String fn, String ln)
        //{
        //    return FirstName == fn 
        //        && LastName == ln;
        //}

        //public bool CheckProfile(String fn, String ln,String em)
        //{
        //    return FirstName == fn 
        //        && LastName == ln 
        //        && EmailAddress == em;
        //}

        public bool CheckProfile(String fn, String ln, String em=null)
        {
            if (em == null) {
                return FullName.FirstName == fn
                    && FullName.LastName == ln;
            } else {
               return FullName.FirstName == fn
                    && FullName.LastName == ln 
                    && EmailAddress == em;
            }
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a Passenger");
        }
    }


}