using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AVIRApi.Models
{
    public class IncidentReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public Guid ID { get; set; }       
        public DateTime CreateTime { get; set; } 
        public DateTime DetectTime { get; set; }
        public DateTime EventTime { get; set; }
        public DateTime CeaseTime { get; set; }  
        public string Category { get; set; }
        public string Ref { get; set; }
        public string Note { get; set; }
        public int ConnCount { get; set; }
        public ICollection<Source> Source { get; set; }
        public ICollection<Target> Target { get; set; }
        public ICollection<Attach> Attach { get; set; }
        public Node Node { get; set; } = default!;
    
    }
}
