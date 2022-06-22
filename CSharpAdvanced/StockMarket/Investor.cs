namespace StockMarket
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Investor
    {
        public HashSet<Stock> Portfolio { get; set; }//To check this again, something is not clear in the task
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count { get { return Portfolio.Count; } }

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
            this.Portfolio = new HashSet<Stock>();
        }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && this.MoneyToInvest >= stock.PricePerShare)
            {
                Portfolio.Add(stock);
                this.MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!this.Portfolio.Any(company => company.CompanyName.Equals(companyName)))
            {
                return $"{companyName} does not exist.";
            }
            if (sellPrice < this.Portfolio.First(c => c.CompanyName.Equals(companyName)).PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }
            Stock company = this.Portfolio.First(c => c.CompanyName.Equals(companyName));
            this.Portfolio.Remove(company);
            return $"{company.CompanyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            return this.Portfolio.FirstOrDefault(c => c.CompanyName.Equals(companyName));
        }

        public Stock FindBiggestCompany()
        {
            if (this.Portfolio.Count == 0)
            {
                return null;
            }
            return this.Portfolio.OrderByDescending(c => c.MarketCapitalization).FirstOrDefault();
        }

        public string InvestorInformation()
        {
            return $"The investor {this.FullName} with a broker {this.BrokerName} has stocks:{Environment.NewLine}{string.Join(Environment.NewLine, this.Portfolio)}";
        }
    }
}
