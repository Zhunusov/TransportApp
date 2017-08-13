using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportApp.DAL.Entities
{
    public class CargoDocument
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Cargo")]
        public int CargoId { get; set; }
        public bool IsDocumentRequired { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("DocumentType")]
        public int DocumentId { get; set; }
        public virtual Cargo Cargo { get; set; }

        public virtual DocumentType DocumentType { get; set; }
    }
}
