using BaseCore.Entities;
using System;

namespace Blog.Domain.Entities
{
    public class GenelAyarlar : Entity<int>
    {
        public string LogoUrl { get; set; }
        public string Favicon { get; set; }
        public bool? AraclarAktif { get; set; }
        public bool? SoruSorAktif { get; set; }
        public bool? DuyurularAktif { get; set; }
        public bool? YazarlarAktif { get; set; }
        public bool? EditorunSectikleriAktif { get; set; }
        public bool? PopulerIceriklerAktif { get; set; }
        public bool? VideoIceriklerAktif { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
