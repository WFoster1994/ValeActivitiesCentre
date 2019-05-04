using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValeActivitiesCentre.Models
{
    public enum DayOptions
    {
        [Display(Name ="Monday")]
        MONDAY,
        [Display(Name ="Tuesday")]
        TUESDAY,
        [Display(Name="Wednesday")]
        WEDNESAY,
        [Display(Name ="Thursday")]
        THURSDAY,
        [Display(Name ="Friday")]
        FRIDAY
    }

    public enum TimeOptions
    {
        [Display(Name ="AM Activity")]
        AM,
        [Display(Name ="PM Activity")]
        PM     
    }

    public class Activity
    {
        /// <summary>
        /// An identification number given to each activity.
        /// </summary>
        public int ActivityID { get; set; }

        /// <summary>
        /// The name of the activity e.g. cooking
        /// or social trip.
        /// </summary>
        [StringLength(30)]
        public string Name { get; set; }

        /// <summary>
        /// A short descripiton of the activity in 
        /// order to give the user of the website an 
        /// idea of what that activity encompasses.
        /// </summary>
        [StringLength(255)]
        public string Description { get; set; }

        /// <summary>
        /// The day that the activity takes place on.
        /// The choices are monday to friday as the centre
        /// is closed Saturday ad Sunday
        /// </summary>
        [Display(Name ="Day of Activity")]
        public DayOptions Day { get; set; }

        /// <summary>
        /// The time slot that the activities takes 
        /// place in. This is either an AM or PM slot.
        /// </summary>
        [Display(Name ="Activity Time Slot")]
        public TimeOptions Time { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}