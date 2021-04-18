using System;

namespace Blog.Domain.DataTransferObjects
{
    public class ToDoListDto
    {
        public int Id { get; set; }
        public string IsinAdi { get; set; }
        public string Icerik { get; set; }
        public int Olusturan { get; set; }
        public int Durum { get; set; }
        public DateTime SonTarih { get; set; }
        public string CreateUserFullName { get; set; }
    }
}
