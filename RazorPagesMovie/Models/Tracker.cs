using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RazorPagesMovie.Models
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

        //working through based on tutorial; modify once you can get this to work
        public TrackerStatus Status { get; set; }
    }

    //working through based on tutorial; modify once you can get this to work
    public enum TrackerStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}
