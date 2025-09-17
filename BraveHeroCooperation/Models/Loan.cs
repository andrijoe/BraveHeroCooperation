using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveHeroCooperation.Models
{
    public class Loan
    {
        public int Id { get; set; }
        [Required] public int MemberId { get; set; }
        public Member Member { get; set; } = null!;
        [Required] public int LoanId { get; set; }
        [Required] public decimal amount { get; set; }
        public decimal outstanding { get; set; }
        public decimal fine { get; set; }
        public int tenorLeft { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required, MaxLength(20)] public string Status { get; set; } = "Pending";
        public decimal Interest { get; set; }
        public decimal InterestFine { get; set; }
        public decimal Tenor { get; set; }
        public int DueDate { get; set; }
        [Required] public decimal totalAmount { get; set; }

        public string? KtpPath { get; set; }
        public string? KkPath { get; set; }
        public string? SlipGajiPath { get; set; }

        public ICollection<Installment> Installments { get; set; } = new List<Installment>();
    }
}
