
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Office_assistant.Model
{
    public class subFood
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Food Name")]
        public string Food_name { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
