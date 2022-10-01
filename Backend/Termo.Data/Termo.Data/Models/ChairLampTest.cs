using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termo.Data.Models
{
    public class ChairLampTest : BaseEntity
    {
        public virtual IList<ChairLampTestPart> ChairLampTestParts { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [ForeignKey("TestId")]
        public string TestId { get; set; }
        public Test Test { get; set; }
    }
}