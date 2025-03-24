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
        private float _total;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChallanTransactionId { get; private set; }

        //// Foreign Key
        //[Required]
        //[ForeignKey("Challan")]
        //public int ChallanId { get; set; }
        //public virtual Challan challan { get; set; } // Navigation Property

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

        public float Total
        {
            get => _total;
            private set
            {
                if (_total != value)
                {
                    _total = value;
                    OnPropertyChanged(nameof(Total));
                }
            }
        }

        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

        public ChallanTransaction(int challanId, int diamond, float rate, int paper)
        {
            //ChallanId = challanId;
            Diamond = diamond;
            Rate = rate;
            Paper = paper;
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            Total = Diamond * Rate + Paper;
            UpdatedAt = DateTime.UtcNow;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
