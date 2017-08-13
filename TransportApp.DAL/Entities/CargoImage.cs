using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransportApp.DAL.Entities
{
    public class CargoImage
    {
        public int CargoId { get; set; }
        [Key]
        public int ImageId { get; set; }
        public byte[] ImageData { get; set; }        
        public string ImageMimeType { get; set; }
        public virtual Cargo Cargo { get; set; }
    }
}
