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
        public IList<ToulousePieronResult> ToulousePieronResult { get; set; }
        public IList<ChairLampResult> ChairLampResult { get; set; }
        public IList<BourdonResult> BourdonResult { get; set; }
    }
}
