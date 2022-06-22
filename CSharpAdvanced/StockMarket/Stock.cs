using System;

namespace StockMarket
{
    public class Stock
    {
        public string CompanyName { get; set; }
        public string Director { get; set; }
        public decimal PricePerShare { get; set; }
        public int TotalNumberOfShares { get; set; }
        public decimal MarketCapitalization { get { return this.PricePerShare * this.TotalNumberOfShares; } } //Calculated property without setter, check if this is viable

        public Stock(string companyName, string director, decimal pricePershare, int totalNumbersPerShare)
        {
            this.CompanyName = companyName;
            this.Director = director;
            this.PricePerShare = pricePershare;
            this.TotalNumberOfShares = totalNumbersPerShare;
        }

        public override string ToString()
        {
            return $"Company: {this.CompanyName}{Environment.NewLine}Director: {Director}{ Environment.NewLine}Price per share: ${this.PricePerShare}{Environment.NewLine}Market capitalization: ${this.MarketCapitalization}";
        }
    }
}
