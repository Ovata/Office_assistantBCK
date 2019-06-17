using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Office_assistant.Model
{
    public class Food
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Food_name { get; set; }
        [Required]
        public int Price { get; set; }
    }

    
}
