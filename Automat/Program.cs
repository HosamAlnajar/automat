using System.Diagnostics;
using Automat.Products;

namespace Automat;
class Program
{
    static void Main(string[] args)
    {
        Balance balance = new Balance();

        // Användaren har 10st av varje valör
        List<Cash> wallet = new List<Cash>();

        wallet.Add(new Cash(1, 10));
        wallet.Add(new Cash(5, 10));
        wallet.Add(new Cash(10, 10));
        
        Console.WriteLine("Hej och välkommen!");
        initialOptions();

        void initialOptions()
        {
            Console.WriteLine("Du får välja vad du vill göra:");
            Console.WriteLine("1- Visa alla produkter.");
            Console.WriteLine("2- Kolla dina pengar.");
            Console.WriteLine("3- Avbryt.");

            


            int option = 0;
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {
                defaultCatch(true);
            }

            switch (option)
            {
                case 1:
                    showProducts();
                    break;
                case 2:
                    moneyOptions();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Tack för att du använder våra produkter. Du är alltid välkommen.");
                    Console.WriteLine("Du får tillbaka: " + getBalanceToReturn());
                    break;
                default:
                    defaultCatch(true);
                    break;

            }
        }

        // todo
        int getBalanceToReturn()
        {
            if(balance.userBalance < 5 && balance.userBalance > 1)
            {
                wallet.Add(new Cash(5, 1));
                return 5;
            }

            else if (balance.userBalance < 10)
            {
                wallet.Add(new Cash(10, 1));
                return 10;
            }
            else if (balance.userBalance > 10)
            {
                wallet.Add(new Cash(20, 1));
                return 20;
            }
            return balance.userBalance;
        }

        void moneyOptions()
        {
            Console.Clear();
            Console.WriteLine("Din saldo är: " + balance.userBalance + "kr");
            Console.WriteLine("1- Lägg in mer pengar.");
            Console.WriteLine("2- <= Gå tillbaka.");
            int option = 0;
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {
                defaultCatch(true);
            }

            switch (option)
            {
                case 1:
                    charge();
                    break;
                case 2:
                    defaultCatch(true);
                    break;
            }
        }

        void showProducts()
        {
            Bag bag = new Bag("Axelremsväska", 30, "Fluffig väska med axelrem fuskpäls hjärtan rymlig med dragkedja Pink Pink");
            Candy candy = new Candy("Godisnudlar", 20, "En revolutionerande produkt som ser ut som nudlar men smakar godis!");
            Cola cola = new Cola("Cola", 6, "Köp hem enskilda burkar och flaskor eller slå till på ett storpack.");
            Console.Clear();
            Console.WriteLine("1- " + bag.name);
            Console.WriteLine("2- " + candy.name);
            Console.WriteLine("3- " + cola.name);
            Console.WriteLine("4- <= Tillbaka");
          
            int option = 0;
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {
                defaultCatch();
            }

            switch (option)
            {
                case 1:
                    singleProduct(bag.name, bag.price, bag.description);
                    Console.WriteLine("Vill du köpa och använda produkten?");
                    Console.WriteLine("1- Köp nu");
                    Console.WriteLine("2- Gå till fösta meny");
                    int option2 = 0;
                    try
                    {
                        option2 = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        defaultCatch();
                    }

                    switch (option2)
                    {
                        case 1:
                            checkBalance(bag.price);
                            bag.Buy(bag.price, balance);
                            bag.Use();
                            initialOptions();
                            break;
                        case 2:
                            initialOptions();
                            break;
                    }
                    break;
                case 2:
                    singleProduct(candy.name, candy.price, candy.description);
                    Console.WriteLine("Vill du köpa och använda produkten?");
                    Console.WriteLine("1- Köp nu");
                    Console.WriteLine("2- Gå till fösta meny");
                    int option3 = 0;
                    try
                    {
                        option3 = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        defaultCatch();
                    }

                    switch (option3)
                    {
                        case 1:
                            checkBalance(candy.price);
                            candy.Buy(candy.price, balance);
                            candy.Use();
                            initialOptions();
                            break;
                        case 2:
                            initialOptions();
                            break;
                    }
                    break;
                case 3:
                    singleProduct(cola.name, cola.price, cola.description);
                    Console.WriteLine("Vill du köpa och använda produkten?");
                    Console.WriteLine("1- Köp nu");
                    Console.WriteLine("2- Gå till fösta meny");
                    int option4 = 0;
                    try
                    {
                        option4 = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        defaultCatch();
                    }

                    switch (option4)
                    {
                        case 1:
                            checkBalance(cola.price);
                            cola.Buy(cola.price, balance);
                            cola.Use();
                            initialOptions();
                            break;
                        case 2:
                            initialOptions();
                            break;
                    }

                    break;
                case 4:
                    initialOptions();
                    break;
                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    Console.WriteLine("-----------------------------------");
                    initialOptions();
                    break;
            }

        }

        bool checkBalance(int price)
        {
            if (balance.userBalance >= price)
            {
                return true;
            }
            Console.Clear();
            Console.WriteLine("Du har inte tillräckligt med pengar. Din saldo är: " + balance.userBalance + "kr, men produkten kostar: " + price + "kr. Vill du lägga in mer pengar?");
            Console.WriteLine("1- Ja");
            Console.WriteLine("2- Avbryt");
            int option2 = 0;
            try
            {
                option2 = int.Parse(Console.ReadLine());
            }
            catch
            {
                defaultCatch();
            }

            switch (option2)
            {
                case 1:
                    charge();
                    break;
                case 2:
                    showProducts();
                    break;
            }

            return false;
        }

        void singleProduct(string name, int price, string description)
        {
            Console.Clear();
            Console.WriteLine("########### Produktbeskrivning ##############");
            Console.WriteLine("Namn: " + name);
            Console.WriteLine("Pris: " + price);
            Console.WriteLine("Beskrivning: " + description);
            Console.WriteLine("##############################################");
        }

        void defaultCatch(bool initial = false)
        {
            Console.Clear();
            Console.WriteLine("Du han angett fel val, försök igen.");
            Console.WriteLine("-----------------------------------");
            if(initial)
            {
                initialOptions();
            }
            else
            {
                showProducts();
            }
        }

        void charge()
        {
            getCach();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Vad vill du använda för kontanter?");
            Console.WriteLine("1- En krona.");
            Console.WriteLine("2- 5 kronor.");
            Console.WriteLine("3- 10 kronor.");
            Console.WriteLine("4- <= Gå tillbaka.");
            
            int option = 0;
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {
                defaultCatch(true);
            }

            switch (option)
            {
                case 1:
                    checkCach(1);
                    balance.userBalance += 1;
                    Console.WriteLine("Du har matat in i automaten " + balance.userBalance + "kr");
                    charge();
                    break;
                case 2:
                    checkCach(5);
                    balance.userBalance += 5;
                    Console.WriteLine("Du har matat in i automaten " + balance.userBalance + "kr");
                    charge();
                    break;
                case 3:
                    checkCach(10);
                    balance.userBalance += 10;
                    Console.WriteLine("Du har matat in i automaten " + balance.userBalance + "kr");
                    charge();
                    break;
                case 4:
                    initialOptions();
                    break;
                default:
                    defaultCatch(true);
                    break;
            }
        }

        void checkCach(int type)
        {
            foreach (Cash cach in wallet)
            {
                if(cach.type == type)
                {
                    if (cach.count > 0)
                    {
                        cach.count--;
                    }
                    else
                    {
                        Console.WriteLine("Du har 0st av " + cach.type + "kr");
                        Console.WriteLine("Vill du lägga in en annan typ av kontanter?");
                        Console.WriteLine("1- Ja");
                        Console.WriteLine("2- Avbryt");
                        int option = 0;
                        try
                        {
                            option = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            defaultCatch(true);
                        }
                        switch (option)
                        {
                            case 1:
                                Console.Clear();
                                charge();
                                break;
                            case 2:
                                defaultCatch(true);
                                break;

                        }
                    }
                }
            }
        }

        void getCach()
        {
            Console.WriteLine("Dina kontanter är:");
            foreach (Cash cach in wallet)
            {
                Console.WriteLine(cach.count + "st av " + cach.type + "kr");
            }
        }
    }
}

