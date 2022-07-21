using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AVIRApi.Models
{
    public class ThreatProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public Guid ID { get; set; }        
        public Guid IncidentReportID { get; set; }
        public long Age {get; private set;}
        public long LastSeen { get; private set; }
        public int NumOccurences { get; private set; }
        public int LocationFrequency { get; private set; }
        public double Score { get; private set; }
        
    }
}