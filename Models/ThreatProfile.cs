using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AVIRApi.Models
{
    public class ThreatProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public Guid ID { get; set; }      
        [ForeignKey("IncidentReport")]
        public Guid IncidentReportID { get; set; }
        public long Age {get;  set;}
        public long LastSeen { get;  set; }
        public int NumOccurences { get;  set; }
        public int LocationFrequency { get;  set; }
        public double Score { get;  set; }
        
    }
}