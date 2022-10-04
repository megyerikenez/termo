using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termo.Data.Models
{
    public class BourdonTest : BaseEntity
    {
        public int incorrectlyMarked { get; set; }
        public int incorrectlyIgnored { get; set; }
        public int correctlyMarked { get; set; }
        public int correctlyIgnored { get; set; }
        public int linesViewed { get; set; }
        public int charsViewed { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [ForeignKey("TestId")]
        public string TestId { get; set; }
        public Test Test { get; set; }
    }
}