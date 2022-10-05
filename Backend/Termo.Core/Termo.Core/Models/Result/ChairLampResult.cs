using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termo.Core.Models.ChairLamp;

namespace Termo.Core.Models.Result
{
    public class ChairLampResult
    {
        public virtual IList<ChairLampItemDto> Values { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
