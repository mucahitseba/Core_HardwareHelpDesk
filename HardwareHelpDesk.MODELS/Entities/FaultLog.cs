using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HardwareHelpDesk.MODELS.Entities
{
    [Table("FaultsLog")]
    public class FaultLog
    {
        [Key]
        [DisplayName("Arıza Log ID")]
        public int FaultLogId { get; set; }

        [DisplayName("Arıza ID")]
        public Guid FaultId { get; set; }
        [DisplayName("MusteriId ID")]
        public string CustomerId { get; set; }
        [DisplayName("Teknisyen ID")]
        public string TechnicianId { get; set; }
        [DisplayName("Tarih")]
        public DateTime History { get; set; } = DateTime.Now;
        [DisplayName("İşlem")]
        public string Operation { get; set; }
        [DisplayName("İşlem Açıklaması")]
        public string OperationDescription { get; set; }

        [ForeignKey("FaultId")]
        public virtual Fault Fault  { get; set; }

    }
}
