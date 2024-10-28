namespace RpgTextGame.Models
{
     public class Currency
    {
        public int Gold {  get; private set; }
        public int Silver {  get; private set; }
        public int Bronze {  get; private set; }

        public Currency(int gold = 0, int silver = 0,int bronze = 0) {
            Gold = gold;
            Silver = silver;
            Bronze = bronze;                             
            CurrencyConversion();
        }

        public int TotalMoney()
        {
            return (Gold * 10000) + (Silver * 100) + Bronze;
        }

        public void AddCurrency(int gold,int silver, int bronze)
        {
            Gold += gold;
            Silver += silver;
            Bronze += bronze;
            CurrencyConversion();
        }

        public bool SubtractCurrency(int gold,int silver,int bronze) {
            
            int totalBronze = (Gold*10000) + (Silver*100) + Bronze;
            int BronzeToDeduct = (gold*10000) + (silver*100) + bronze;

            if (totalBronze < BronzeToDeduct)
            {
                return false;
            }

                totalBronze -= BronzeToDeduct;
                Gold = totalBronze / 10000;
                Silver = (totalBronze % 10000) / 100;
                Bronze = totalBronze % 100;
                return true;
        }

        public void CurrencyConversion()
        {
            if(Bronze>=100)
            {
                Silver += Bronze/100;
                Bronze = Bronze % 100;
            }

            if (Silver >= 100)
            {
                Gold += Silver / 100;
                Silver = Silver % 100;
            }
        }

        public string PrintCurrency()
        {
            var currencyParts = new List<string>();

            if (Gold > 0)
            {
                currencyParts.Add($"Gold: {Gold}");
            }

            if (Silver > 0)
            {
                currencyParts.Add($"Silver: {Silver}");
            }

            if (Bronze > 0)
            {
                currencyParts.Add($"Bronze: {Bronze}");
            }

           if (currencyParts.Count == 0)
           {
               //Console.WriteLine("No currency available.");
               return "No currency available.";
            }
           else
           {
              // Join the parts with a comma and space for a cleaner output
               //Console.WriteLine(string.Join(", ", currencyParts));
               return string.Join(", ", currencyParts);
           }
        }
    }
}
