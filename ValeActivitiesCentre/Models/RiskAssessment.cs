using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        /// A section for notes about any risks related to
        /// physical health that have been ientified e.g.
        /// use of a wheelchair or balance difficulties. 
        /// Here, the writer will write strategies to 
        /// work with any physical difficulties.
        /// 
        /// The way in which this assessment should be laid out 
        /// is in a list form so the assessment does not become 
        /// an extensive form of block text.
        /// </summary>
        [Display(Name ="Physical Health Risks and Strategies")]
        public string PhysicalHealthNotes { get; set; }

        /// <summary>
        /// A section for notes relating to the individual's
        /// mental health (past or present) that they will
        /// write about along with strategies that work best
        /// for that individual's needs.
        /// </summary>
        [Display(Name ="Mental Health Risks and Strategies")]
        public string MentalHealthNotes { get; set; }

        /// <summary>
        /// A section to write about the client's social 
        /// factors e.g. confidence and factors that may 
        /// have contributed to this, as well as strategies
        /// for working with these social factors.
        /// </summary>
        [Display(Name ="Social Factors and Strategies")]
        public string SocialHealthNotes { get; set; }

        /// <summary>
        /// A space for the individual writing the risk 
        /// assessment to add in any other risks that they
        /// can identify and strategies to help work with
        /// them.
        /// </summary>
        [Display(Name ="Any Other Unmentioned Factors/Risks")]
        public string OtherNotes { get; set; }

        public virtual Client Client { get; set; }
        
    }
}