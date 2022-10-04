using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termo.Core.Models.ToulousePieron;
using Termo.Data.Models;

namespace Termo.Core.Models
{
    public class Result
    {
        public List<ToulousePieronDto> ToulousePieronResult { get; set; }
        public List<ChairLampTest> ChairLampResult { get; set; }
        public List<BourdonTest> BourdonResult { get; set; }
    }
}
