using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CodeFirst.Entity
{
    class Ev
    {
        [Key]
        public int ev_id { get; set; }
        public string adres { get; set; }
        public string isitma { get; set; }
        public int banyosayisi { get; set; }
        public int fiyat { get; set; }
        public int kat { get; set; }
        public int odasayisi { get; set; }
        public string cephe { get; set; }
        public int metrekare { get; set; }
        public string durum { get; set; }
        public ICollection<Satislar> Satislars { get; set; }
    }
}
