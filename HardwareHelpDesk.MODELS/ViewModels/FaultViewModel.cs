using HardwareHelpDesk.MODELS.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HardwareHelpDesk.MODELS.ViewModels
{
    public class FaultViewModel
    {
        [Key]
        [DisplayName("Arıza ID")]
        public Guid FaultID { get; set; } = Guid.NewGuid();
        [DisplayName("Müşteri ID")]
        [Required]
        public string CustomerId { get; set; } = String.Empty;
        [DisplayName("Operatör ID")]
        public string OperatorId { get; set; } = String.Empty;
        [DisplayName("Teknisyen ID")]
        public string TechnicianId { get; set; } = String.Empty;
        [DisplayName("Arıza Bildirim Tarihi")]
        public DateTime FaultNotifyDate { get; set; } = DateTime.Now;

        [DisplayName("Arıza Sonuçlanma Tarihi")]
        public DateTime? FaultResultDate { get; set; }

        [DisplayName("Arıza Durumu")]
        public FaultStates FaultState { get; set; } = FaultStates.Uncompleted;

        [DisplayName("Operatöre Atanmış mı ?")]
        public bool AssignedOperator { get; set; } = false;

        [DisplayName("Ürün Resmi Ekleyiniz :")]
        public string FaultPath { get; set; }

        [DisplayName("Arızali Ürün Resmini Ekleyiniz :")]
        public IFormFile PostedFileFault { get; set; }

        //todo view modelyapcaksın bu alanı resim için.
        [DisplayName("Fatura Resmini Ekleyiniz")]
        public string InvoicePath { get; set; }

        [DisplayName("Ürünün Fatura Resmini Ekleyiniz.")]
        public IFormFile PostedFileInvoice { get; set; }

        public string FaultDescription { get; set; }
        public string Adress { get; set; }
        public bool haveJob { get; set; } = false;
        public string TechnicianDescription { get; set; }

    }
}
