using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AVIRApi.Models
{
    public class Node
    {
        [Key]
        public Guid ID { get; set; }
        public Guid IncidentReportID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string SW { get; set; }
        public string AggrWin { get; set; }
        public double GPSLatitude { get; set; } = default!;
        public double GPSLongitude { get; set; } = default!;
        public string VehicleStatus { get; set; } = default!;
        public long GPSSpeed { get; set; }
        public string GPSDirection { get; set; }
        public bool EngineStatus { get; set; } = default!;
        
    }
}