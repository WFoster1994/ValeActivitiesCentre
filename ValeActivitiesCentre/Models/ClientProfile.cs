﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValeActivitiesCentre.Models
{
    public class ClientProfile
    {
        [ForeignKey("Client")]
        public int ClientProfileID { get; set; }

        /// <summary>
        /// A section of the client profile where details are written about
        /// the most effective way of supporting and communicating with the 
        /// client
        /// </summary>
        [Display(Name ="The best communication approach for me")]
        public string BestComunicationApproach { get; set; }

        /// <summary>
        /// A section of the client profile where details are laid out about 
        /// what to avoid when supporting the client i.e. what forms of 
        /// communication does not work for them.
        /// </summary>
        [Display(Name ="The communication approach that does not work for me")]
        public string PoorCoomunicationApproach { get; set; }

        /// <summary>
        /// The goals, dreams and objectives that the client has set out
        /// for themselves.
        /// </summary>
        [Display(Name ="Goals and Objectives")]
        public string GoalsAndObjectives { get; set; }

        public virtual Client Client { get; set; }
    }

}