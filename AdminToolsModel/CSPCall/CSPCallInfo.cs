using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace AdminToolsModel.CSPCall
{
    public class CSPCallInfo
    {
        public List<CSPCallDetails> AddList { get; set; }

        public List<CSPCallDetails> CloseList { get; set; }

        public List<CSPCallDetails> SearchList { get; set; }
        
        public CSPCallSet CallSet { get; set; }
    }
}
