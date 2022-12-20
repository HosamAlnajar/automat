using System;
namespace Automat.Products
{
	public class Bag : Attributes, IActions
    {
        public Bag(string Name, int Price, string Description)
        {
            this.name = Name;
            this.price = Price;
            this.description = Description;
        }

        public void Buy(int price, Balance balance)
        {
            // minska pengarna i balance
            balance.userBalance = balance.userBalance - price;
            Console.WriteLine("************** Tack! ******************");
            Console.WriteLine("Tack för ditt köp!");
        }

        public void Use()
        {
            Console.WriteLine("Grattis, du använder nu den nya väskan");
            Console.WriteLine("****************************************");

        }

        public void Description()
        {
            // @todo
        }
    }
}

