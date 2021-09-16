using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FilmApp.Models
{
    public class Glumac
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Naziv { get; set; }
    }
}
