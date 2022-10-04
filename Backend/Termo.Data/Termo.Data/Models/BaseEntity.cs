using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termo.Data.Models
{
    public abstract class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
