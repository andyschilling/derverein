using System;
using DerVerein.Data;

namespace DerVerein.Model
{
    public class Posting
    {
        public Posting()
        {
            Id = Guid.NewGuid();
            PostingDate = DateTime.Now;
        }

        public Guid Id { get; set; }

        public string DocumentNumber { get; set; }

        public DateTime PostingDate { get; set; }

        public DateTime DocumentDate { get; set; }

        public string Description { get; set; }

        public PostingType Type { get; set; }

        public string CurrencyKey { get; set; }

        public double TranslationRate { get; set; }

        public double NetAmount { get; set; }

        public  double TaxPercentage1 { get; set; }

        public double TaxPercentage2 { get; set; }

        public double TaxAmount1 { get; set; }

        public double TaxAmount2 { get; set; }

        public double GrossAmount { get; set; }

        public double Discount { get; set; }

        public double InvoiceAmount { get; set; }
    }
}