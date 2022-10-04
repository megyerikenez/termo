using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termo.Data.Models;

namespace Termo.Core.Models.ChairLamp
{
    public class ChairLampItemDto
    {
        public int IncorrectlyIgnored { get; set; }
        public int IncorrectlyMarked { get; set; }
        public int CorrectlyMarked { get; set; }
        public int CorrectlyIgnored { get; set; }
        public int PicturesRevised { get; set; }
    }
}
