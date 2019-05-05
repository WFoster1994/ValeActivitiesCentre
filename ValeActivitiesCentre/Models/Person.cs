﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ValeActivitiesCentre.Models
{
    public class Person
    {
        /// <summary>
        /// A unique number given to a person, who
        /// is either a staff member or client
        /// </summary>
        public int PersonID { get; set; }

        /// <summary>
        /// The Forename of any given person.
        /// </summary>
        [Required, StringLength(20), Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// The surname of any given person.
        /// </summary>
        [Required, StringLength(20), Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// The phone number of a person, assigned to a home phone.
        /// </summary>
        [StringLength(16), DataType(DataType.PhoneNumber), Display(Name = "Home Phone")]
        public string HomePhoneNumber { get; set; }

        /// <summary>
        /// The phone number of a person, assigned to their mobile phone.
        /// </summary>
        [StringLength(16), DataType(DataType.PhoneNumber), Display(Name = "Mobile Phone")]
        public string MobilePhoneNumber { get; set; }

        /// <summary>
        /// An e-mail address held by a person by which they can be contacted
        /// </summary>
        [StringLength(100), Display(Name = "E-mail Address")]
        public string Email { get; set; }

        /// <summary>
        /// The date of birth of a person
        /// </summary>
        [Required, DataType(DataType.DateTime), Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy/mm/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// A boolean statement that refers to whether or not the person 
        /// concerned is a customer.
        /// </summary>
        [Display(Name = "Client")]
        public bool IsClient { get; set; }

        /// <summary>
        /// A second boolean statement that the person will be selected
        /// if the person concerned is a member of staff 
        /// </summary>
        [Display(Name = "Staff")]
        public bool IsStaff { get; set; }

        /// <summary>
        ///  The URL of the image of the person being used on the website. 
        ///  Only staff members and clients who consent to this will have 
        ///  their image viewable on the website.
        /// </summary>
        public String ImageURL { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName;  }
        }

        public virtual Staff Staff { get; set; }

        public virtual Client Client { get; set; }

    }
}