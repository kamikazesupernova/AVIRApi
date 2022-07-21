using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AVIRApi.Models
{
    public class Attach
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public Guid ID { get; set; }
        public Guid IncidentReportID { get; set; }
        public string Handle { get; set; } = default!;
        public string FileName { get; set; } = default!;
        public string Type { get; set; } = default!;
        public string ContentType { get; set; } 
        public string Hash { get; set; } = default!;
        public int Size { get; set; }
        public string Ref { get; set; } = default!;
        public string ContentEncoding { get; set; } = default!;
        public string Content { get; set; } = default!;
    }
}