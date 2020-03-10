using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValeActivitiesCentre.Models
{
    public class ActivitySlot
    {
        //Identity number assigned to each activty slot
        public int ActivitySlotID { get; set; }


        //Each activity slot is assigned to an activity 
        public Nullable<int> ActivityID { get; set; }
        public virtual Activity Activity { get; set; }

        //Each activity slot is booked by a client
        public Nullable<int> ClientID { get; set; }
        public virtual Client Client { get; set; }

    }
}