using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValeActivitiesCentre.Models
{
    public class RiskAssessment
    {
        /// <summary>
        /// A specific identification number assigned
        /// to each risk assessment.
        /// </summary>
        public int RiskAssessmentID { get; set; }

        /// <summary>
        /// A section for notes about any risks that
        /// have been ientified. Here, the writer will
        /// write triggers and strategies
        /// </summary>
        public string Notes { get; set; }


        public virtual Client Client { get; set; }
        
    }
}