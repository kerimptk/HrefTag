using System;

namespace Blog.Domain.DataTransferObjects
{
    public class CekilisSonuclariDto
    {
        public string CekilisiYapan { get; set; }
        public string CekilisAdi { get; set; }
        public DateTime? CekilisTarihi { get; set; }
        public int? AsilSayisi { get; set; }
        public int? YedekSayisi { get; set; }
        public string CekilisListesi { get; set; }
        public string AsilKazananlar { get; set; }
        public string YedekKazananlar { get; set; }
        public bool? YayinlansinMi { get; set; }
    }
}
