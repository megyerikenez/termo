using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termo.Core.Models.ToulousePieron
{
    public class ToulousePieronDto : BaseDto
    {
        public int IncorrectlyMarked { get; set; }
        public int IncorrectlyIgnored { get; set; }
        public int CorrectlyMarked { get; set; }
        public int CorrectlyIgnored { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
