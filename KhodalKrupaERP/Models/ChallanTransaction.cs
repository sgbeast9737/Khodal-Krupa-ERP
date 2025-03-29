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
        private float _rate;
        private int _paper;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChallanTransactionId { get; private set; }

        // Foreign Key
        [Required]
        public int ChallanId { get; private set; }
        public virtual Challan Challan { get; set; } // Navigation Property

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

        public float Rate
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

        public float Total { get; private set; }

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public ChallanTransaction(int challanId, int diamond, float rate, int paper)
        {
            this.ChallanId = challanId;
            this.Diamond = diamond;
            this.Rate = rate;
            this.Paper = paper;
            this.UpdatedAt = DateTime.Now;
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            this.Total = this.Diamond * this.Rate + this.Paper;
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
