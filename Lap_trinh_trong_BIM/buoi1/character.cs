using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b301026
{
    public class character
    {
        private int _health;
        public int maxhealth { get; set; } = 100;
        public int health
        {
            get {  return _health; }
            set
            {
                if (value < 0) health = 0;
                else if (value > maxhealth)
                {
                    _health = maxhealth;
                    Console.WriteLine("gt value" + value);

                }
                else health = value;
            }
        }
        public character(string Name, int Health) 
            { 
                string name = Name;
                 health =Health;
            }
        
     

    }
    
}
