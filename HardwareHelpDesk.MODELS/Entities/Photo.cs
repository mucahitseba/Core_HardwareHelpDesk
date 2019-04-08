using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HardwareHelpDesk.MODELS.Entities
{
    [Table("Photos")]
    public class Photo
    {
        [Key]
        public int PhotoId { get; set; }

        [Required]
        [DisplayName("Resim Yolu")]
        public string Path { get; set; }
        public Guid FaultId { get; set; }

        [ForeignKey("FaultId")]
        public virtual Fault Fault{ get; set; }
    }
}
