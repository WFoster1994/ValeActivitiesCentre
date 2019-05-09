using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValeActivitiesCentre.Models
{
    public enum Counties
    {
        [Display(Name = "Buckinghamshire")]
        BUCKINGHAMSHIRE,
        [Display(Name = "Bedfordshire")]
        BEDFORDSHIRE,
        [Display(Name = "Hertfordshire")]
        HERTFORDSHIRE,
        [Display(Name = "London")]
        LONDON,
        [Display(Name = "Northamtonshire")]
        NORTHAMTONSHIRE,
        [Display(Name = "Oxfordshire")]
        OXFORDSHIRE
    }

    public class Address
    {
        /// <summary>
        /// A unique identification number used to identify the address details of a person within the database. 
        /// This applies to both clients and staff members. No other attribute was applied as the primary key as the 
        /// other attributes are not unique enough to be an identifier.
        /// </summary>
        [ForeignKey("Person")]
        public int AddressID { get; set; }

        /// <summary>
        /// This is either the name or number of the house a person lives in.
        /// </summary>
        [Required, StringLength(30), Display(Name = "House Name/Number")]
        public string House { get; set; }

        /// <summary>
        /// The name of the street the person lives on as part of their declared address.
        /// </summary>
        [Required, StringLength(30), Display(Name = "Street Name")]
        public string StreetName { get; set; }

        /// <summary>
        /// The name of the town the person lives in.
        /// </summary>
        [StringLength(30), Display(Name = "Town Name")]
        public string TownName { get; set; }

        /// <summary>
        /// A large area of bordered land within a country where a person will live.
        /// </summary>
        public Counties County { get; set; }

        /// <summary>
        /// A set of letters and number used to identify a sector, within a district, within an area. The British makeup of postcodes follows the layout of, 
        /// for example: HP12 3AB. Postcodes do not identify specific houses however, making them not specific enough for use as a primary key.
        /// </summary>
        [Required, StringLength(8)]
        public string Postcode { get; set; }
               

        public virtual Person Person { get; set; }

    }
}