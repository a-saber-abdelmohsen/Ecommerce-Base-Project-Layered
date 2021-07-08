using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class BrandViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Photo { get; set; }
    }
}
