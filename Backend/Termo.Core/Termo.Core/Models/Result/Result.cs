using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termo.Core.Models.Bourdon;
using Termo.Core.Models.ChairLamp;
using Termo.Core.Models.ToulousePieron;
using Termo.Data.Models;

namespace Termo.Core.Models.Result
{
    public class Result
    {
        public IList<ToulousePieronDto> ToulousePieronResult { get; set; }
        public IList<ChairLampDto> ChairLampResult { get; set; }
        public IList<BourdonDto> BourdonResult { get; set; }
    }
}
