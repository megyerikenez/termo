using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termo.Core.Models
{
    public class BaseDto
    {
        public string Token { get; set; }
        [DefaultValue("HU")]
        public string Lang { get; set; } = "HU";
    }
}
