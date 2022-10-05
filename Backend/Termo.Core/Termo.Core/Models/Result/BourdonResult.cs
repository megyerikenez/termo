using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termo.Core.Models.Result
{
    public class BourdonResult
    {
        public int incorrectlyMarked { get; set; }
        public int incorrectlyIgnored { get; set; }
        public int correctlyMarked { get; set; }
        public int correctlyIgnored { get; set; }
        public int linesViewed { get; set; }
        public int charsViewed { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
