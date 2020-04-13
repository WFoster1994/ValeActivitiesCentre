using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValeActivitiesCentre.Models
{
    public enum DepartmentOptions
    { 
        [Display(Name = "Management")]
        MANAGEMENT,
        [Display(Name = "Care")]
        CARE        
    }

    public enum JobPositionOptions
    {
        [Display(Name = "Company Director")]
        COMPANY_DIRECTOR,
        [Display(Name = "Site Manager")]
        SITE_MANAGER,
        [Display(Name = "Site Supervisor")]
        SITE_SUPERVISOR,
        [Display(Name = "Activities Organiser")]
        ACTIVITIES_ORGANISER,
        [Display(Name = "Apprentice")]
        APPRENTICE
    }

    public class Staff
    {
        /// <summary>
        /// A specific identification number to identify the 
        /// member of staff within the database.
        /// </summary>
        [ForeignKey("Person")]
        public int StaffID { get; set; }

        /// <summary>
        /// The department that the staff member works for. 
        /// The departments consist of managment and care staff.
        /// </summary>
        public DepartmentOptions Department { get; set; }

        /// <summary>
        /// The specific position that the member of staff holds within 
        /// their department, e.g. Director or Activities Organiser.
        /// </summary>
        [Display(Name = "Job Position")]
        public JobPositionOptions JobPosition { get; set; }

        /// <summary>
        /// A personal profile of the staff member. These would be written by the 
        /// member of staff themselves, however, for this project, some fictional 
        /// ones will be written.
        /// </summary>
        [StringLength(255), Display(Name ="Staff Profile")]
        public string Profile { get; set; }

        public virtual Person Person { get; set; }

        public ICollection<Activity> Activities { get; set; }
                
    }
}