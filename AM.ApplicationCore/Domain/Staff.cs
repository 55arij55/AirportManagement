using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff:Passenger
    {
        public DateTime EmployementDate { get; set; }
        public String Function { get; set; }
        [DataType(DataType.Currency)]
        public double Salary { get; set; }
        internal FullName FullName { get; set; }

        public override string ToString()
        {
            return base.ToString() 
                + " Function: " + Function;
        }
        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("I am a Staff");
        }
    }
}