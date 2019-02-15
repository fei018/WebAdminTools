using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminToolsModel.CSPCall
{
    [Table("CSPCall")]
    public class CSPCallDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(3)]
        [RegularExpression(@"^HHC$|^VIB$",ErrorMessage ="HHC or VIB ?")]
        public string Company { get; set; }

        [Required]
        [MaxLength(30)]
        public string Location { get; set; }

        [Required]
        [MaxLength(30)]
        public string ContactPerson { get; set; }      

        [Required]
        [DataType(DataType.MultilineText)]
        public string Symptom { get; set; }
       
        [Required]
        [MaxLength(5)]
        public string ScheduleTime { get; set; }

        [Required]
        [MaxLength(5)]
        public string ServeTime1 { get; set; }

        [Required]
        [MaxLength(5)]
        public string ServeTime2 { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string ServiceDescription { get; set; }

        [NotMapped]
        public string RequestNO { get; set; }

        [NotMapped]
        public string RequestDate { get; set; }

        //[NotMapped]
        //public string RequestType { get; set; }


    }
}
