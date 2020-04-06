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

        public int ClientID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ActivityID { get; set; }

        public string ActivityName { get; set; }

        public string ActivitySlotNumber { get; set; }

        public DayOptions Day { get; set; }

        public TimeOptions Time { get; set; }

        /// <summary>
        /// Refers to an email being sent to the manager to inform
        /// them of the booking confirmation.
        /// </summary>
        public bool EmailSent { get; set; }

        //Each booking is made by a client
        public virtual Client Client { get; set; }

        //Each booking is for an activity
        public virtual ICollection<Activity> Activities { get; set; }



    }
}