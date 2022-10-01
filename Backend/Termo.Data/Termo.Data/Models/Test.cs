using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termo.Data.Models
{
    public class Test : BaseEntity
    {
        public string Link { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
