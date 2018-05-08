using System;
using System.ComponentModel.DataAnnotations;

namespace WalktoMordor.Models
{

    public class Tracker
    {

        public int ID { get; set; }

        // user ID from AspNetUser table.
        // [ScaffoldColumn(false)]
        public string OwnerID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Distance Traveled")]
        public decimal Distance { get; set; }


        [Display(Name = "Number of Entries")]
        public int DistCount { get; set; }

        [Display(Name = "Total Distance Traveled")]
        public decimal DistTotal { get; set; }


    }
}
