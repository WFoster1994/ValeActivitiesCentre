using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        /// <summary>
        /// An identification number assigned to each booking
        /// </summary>
        public int BookingID {get; set;}

        //The status of the booking in terms of the client's request.
        public BookingStatus BookingStatus { get; set; }

        /// <summary>
        /// Refers to an email being sent to the manager to inform
        /// them of the booking confirmation.
        /// </summary>
        public bool EmailSent { get; set; }

        //Each booking is made by a client (Person)
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }

        //Each booking is for an activity
        public virtual Activity Activity { get; set; }

    }
}