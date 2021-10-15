using Blog.Domain.Entities;

namespace Blog.Domain.DataTransferObjects
{
    public class EtiketYaziDto
    {
        public int Id { get; set; }
        public int YaziId { get; set; }
        public virtual Yazi Yazi { get; set; }
        public int EtiketId { get; set; }
        public virtual Etiket Etiket { get; set; }
    }
}
