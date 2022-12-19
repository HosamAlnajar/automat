using System;
namespace Automat
{
	public interface IActions
	{
        public void Buy(int price);
        public void Use();
        public void Description();
       
    }
}

