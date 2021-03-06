using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Tables {
    public class User {
        public int Id { get; set; }
        [MaxLength(50)]
        public string FullName { get; set; }
        public List<Ad> Ads { get; set; } = new List<Ad>();
    }
}
