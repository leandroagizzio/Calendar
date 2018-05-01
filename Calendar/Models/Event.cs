using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calendar.Models {
    public class Event {

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? StartDate { get; set; }

        [Required]
        [Display(Name = "Finish Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [FinishAfterStart]
        public DateTime? FinishDate { get; set; }

    }
}