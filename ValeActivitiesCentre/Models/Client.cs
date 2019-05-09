using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValeActivitiesCentre.Models
{
    public enum FundingOptions
    {
        [Display (Name ="Council Funding")]
        COUNCIL_FUNDED,
        [Display (Name ="Private Funding")]
        PRIVATE_FUNDING
    }

    public class Client
    {
        /// <summary>
        /// A specific identification number assigned to 
        /// each client who attends the centre.
        /// </summary>
        [ForeignKey("Person")]
        public int ClientID { get; set; }

        /// <summary>
        /// The funding that the client is receiving in
        /// order to pay for their service.
        /// </summary>
        [Required]
        public FundingOptions Funding { get; set; }

        public virtual ClientProfile ClientProfile { get; set; }

        public virtual RiskAssessment RiskAssessment { get; set; }

        public virtual Person Person { get; set; }
    }
}