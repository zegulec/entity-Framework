using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CodeFirst.Entity
{
    class Musteri
    {
        [Key]
        public string tckimlik { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string adres { get; set; }
        public string telefon { get; set; }
        public string email { get; set; }
        public int yas { get; set; }
        public ICollection<Satislar> Satislars { get; set; }
    }
}
