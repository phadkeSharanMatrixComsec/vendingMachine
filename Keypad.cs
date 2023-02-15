using System;

namespace VendingMachineProject
{
    class Keypad
    {
        public Keypad(){}

        public int readKey()
        {
            string input = Console.ReadLine();
            int value;
            
            if(int.TryParse(input, out value) && value > 0)
            {
                return value;
            }
            else
            {
                return -1;
            }
        }
    }
}