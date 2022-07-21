using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AVIRApi.Models
{
    public class Source
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public Guid ID { get; set; }
        public Guid IncidentReportID { get; set; }
        public string Type { get; set; }
        public string IP4 { get; set; }
        public string IP6 { get; set; }
        public string Hostname { get; set; }
        public string URL { get; set; } 
        public string Proto { get; set; } 
        public string AttachHand { get; set; } 
        public string Netname { get; set; }
    }
}