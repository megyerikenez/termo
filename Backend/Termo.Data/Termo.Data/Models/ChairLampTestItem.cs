using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termo.Data.Models
{
    public class ChairLampTestItem : BaseEntity
    {
        public int Minute { get; set; }
        public int IncorrectlyIgnored { get; set; }
        public int IncorrectlyMarked { get; set; }
        public int CorrectlyMarked { get; set; }
        public int CorrectlyIgnored { get; set; }
        public int PicturesRevised { get; set; }

        [ForeignKey("ChairLampTestId")]
        public string ChairLampTestId { get; set; }
        public ChairLampTest ChairLampTest { get; set; }
    }
}
