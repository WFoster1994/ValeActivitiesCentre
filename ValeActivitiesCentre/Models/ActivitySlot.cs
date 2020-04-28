using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ValeActivitiesCentre.Models
{
    public class ActivitySlot
    {
        //Identity number assigned to each activty slot
        public int ActivitySlotID { get; set; }

        /// <summary>
        /// The activity slot number that will be viewable 
        /// on the booking system for the client to see.
        /// </summary>
        [Required, StringLength(1), Display(Name ="Activity Slot Number")]
        public string ActivitySlotNumber { get; set; }

        //Each activity slot is assigned to an activity 
        //public Nullable<int> ActivityID { get; set; }
        public virtual Activity Activity { get; set; }

        public Nullable<int> BookingID { get; set; }
        public virtual Booking Booking { get; set; }

    }
}