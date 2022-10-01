using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termo.Data.Models
{
    public class ToulousePieronTest : BaseEntity
    {
        public int IncorrectlyMarked { get; set; }
        public int IncorrectlyIgnored { get; set; }
        public int CorrectlyMarked { get; set; }
        public int CorrectlyIgnored { get; set; }
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [ForeignKey("TestId")]
        public string TestId { get; set; }
        public Test Test { get; set; }
    }
}