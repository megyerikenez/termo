using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termo.Data.Models;

namespace Termo.Core.Models.ChairLamp
{
    public class ChairLampDto : BaseDto
    {
        public virtual IList<ChairLampItemDto> ChairLampParts { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
