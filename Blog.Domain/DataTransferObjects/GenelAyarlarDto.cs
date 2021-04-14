using System;

namespace Blog.Domain.DataTransferObjects
{
    public class GenelAyarlarDto
    {
        public int Id { get; set; }
        public string LogoUrl { get; set; }
        public string Favicon { get; set; }
        public bool AraclarAktif { get; set; }
        public bool EditorunSectikleriAktif { get; set; }
        public bool PopulerIceriklerAktif { get; set; }
        public bool VideoIceriklerAktif { get; set; }
        public DateTime UpdateDate  { get; set; }
    }
}
