using System;
namespace Automat
{
	public interface IActions
	{
        public void Buy(int price, Balance balance);
        public void Use();
        public void Description();
       
    }
}

