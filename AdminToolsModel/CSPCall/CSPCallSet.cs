using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace AdminToolsModel.CSPCall
{
    public class CSPCallSet
    {
        [Required]
        public  string LoginName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public  string Password { get; set; }

        [Required]
        public  string Assignto { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public  string StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public  string EndDate { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$")]
        public  string DayCalls { get; set; }
    }
}
