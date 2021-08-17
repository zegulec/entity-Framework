using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Entity
{
    class Satislar
    {
        [Key]
        public int satis_id { get; set; }
        public string tc_kimlik { get; set; }
        public string evid { get; set; }
        public Musteri Musteris { get; set; }
        public Ev Evs { get; set; }
    }
}
