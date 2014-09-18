using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evolita.Admin.Web.Models
{
    public class CreateStrategyModel
    {
        [Required]
        public string Name { get; set; }
    }
}