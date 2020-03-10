using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ValeActivitiesCentre.Models
{
    public enum BookingStatus
    {
        [Display(Name = "Confirmed")]
        CONFIRMED,
        [Display(Name = "Pending")]
        PENDING,
        [Display(Name = "Declined")]
        Declined

    }

    public class Booking
    {
        [ForeignKey("Client")]
        public int BookingID {get; set;}

        //The status of the booking in terms of the client's request.
        public BookingStatus BookingStatus { get; set; }

        /// <summary>
        /// Refers to an email being sent to the manager to inform
        /// them of the booking confirmation.
        /// </summary>
        public bool EmailSent { get; set;}

        //Each booking is made by a client
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }

        //Each booking is for an activity
        public int ActivityID { get; set; }
        public virtual Activity Activity { get; set; }

        //Each booking take an activity slot.
        public int ActivitySlotID { get; set; }
        public virtual ActivitySlot ActivitySlot { get; set; }



    }
}