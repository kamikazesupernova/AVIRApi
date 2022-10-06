using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AVIRApi.Models
{
    public class Target
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public Guid ID { get; set; }
        [ForeignKey("IncidentReport")]
        public Guid IncidentReportID { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public bool Spoofed { get; set; }
        public string IP4 { get; set; }
        public bool? Anonymised { get; set; }
    }
}