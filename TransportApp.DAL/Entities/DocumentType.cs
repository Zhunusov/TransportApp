using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportApp.DAL.Entities
{
    public class DocumentType
    {       
        public DocumentType()
        {
            CargoDocuments = new HashSet<CargoDocument>();
            //TransportDocuments = new HashSet<TransportDocument>();
            //UserDocuments = new HashSet<UserDocument>();
        }

        public string Description { get; set; }
        [Key]
        public int DocumentId { get; set; }

        [Column("DocumentType")]
        [Required]
        public string DocumentType1 { get; set; }        
        public virtual ICollection<CargoDocument> CargoDocuments { get; set; }        
        //public virtual ICollection<TransportDocument> TransportDocuments { get; set; }        
        //public virtual ICollection<UserDocument> UserDocuments { get; set; }
    }
}
