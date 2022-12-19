using System;

namespace Automat
{
	public class Cash
    {
        String Type { get; set; }
        int Count { get; set; }

        public Cash(string type, int count)
        {
            this.Type = type;
            this.Count = count;
        }  

    }

}

