using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FilmApp.Models
{
    public class film
    {
        public int Id { get; set; }
        

        [Required, MaxLength(40)]
        public string Ime { get; set; }
        

        [DataType(DataType.Date)]
        [Display(Name ="Datum Izdanja"), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Dat { get; set; }

        [MaxLength(50)]
        public string Zanr { get; set; }


        [Display(Name = "Glavni glumac")]
        public Glumac Glumac { get; set; }
        public int GlumacId { get; set; }
    }
}
