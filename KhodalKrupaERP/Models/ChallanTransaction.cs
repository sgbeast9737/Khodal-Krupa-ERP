using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhodalKrupaERP.Models
{
    public class ChallanTransaction : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _diamond;
        private double _rate;
        private int _paper;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChallanTransactionId { get; private set; }

        // Foreign Key
        [Required]
        public int ChallanId { get; private set; }
        public virtual Challan Challan { get; set; } // Navigation Property

        [Required]
        public string DesignNo { get; set; }

        // Foreign Key
        [Required]
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; } // Navigation Property

        public int Diamond
        {
            get => _diamond;
            set
            {
                if (_diamond != value)
                {
                    _diamond = value;
                    OnPropertyChanged(nameof(Diamond));
                    CalculateTotal();
                }
            }
        }

        public double Rate
        {
            get => _rate;
            set
            {
                if (_rate != value)
                {
                    _rate = value;
                    OnPropertyChanged(nameof(Rate));
                    CalculateTotal();
                }
            }
        }

        public int Paper
        {
            get => _paper;
            set
            {
                if (_paper != value)
                {
                    _paper = value;
                    OnPropertyChanged(nameof(Paper));
                    CalculateTotal();
                }
            }
        }

        public double Total { get; private set; }

        public DateTime UpdatedAt { get; set; }

        public ChallanTransaction(int challanId, string designNo, int serviceId, int diamond, double rate, int paper)
        {
            this.ChallanId = challanId;
            this.DesignNo = designNo;
            this.ServiceId = serviceId;
            this.Diamond = diamond;
            this.Rate = Math.Round(rate,4);
            this.Paper = paper;
            this.UpdatedAt = DateTime.Now;
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            this.Rate = Math.Round(this.Rate, 4);
            double total = this.Diamond * this.Rate + this.Paper;

            this.Total = Math.Round(total,4);
            this.UpdatedAt = DateTime.Now;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Empty Constructor for EF
        public ChallanTransaction() { }
    }
}
