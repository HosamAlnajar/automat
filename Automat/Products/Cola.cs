using System;
namespace Automat.Products
{
	public class Cola : Attributes, IActions
    {
  
        public Cola(string Name, int Price, string Description)
        {
            this.name = Name;
            this.price = Price;
            this.description = Description;
        }


        public void Buy(int price, Balance balance)
        {
            balance.userBalance = balance.userBalance - price;
            Console.WriteLine("************** Tack! ******************");
            Console.WriteLine("Tack för ditt köp!");
        }

        public void Use()
        {
            Console.WriteLine("Drick hela flaskan nu :)");
            Console.WriteLine("****************************************");
        }

        public void Description()
        {
            // @todo
        }
    }
}

