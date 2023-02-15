using System;

namespace VendingMachineProject
{
    class Transactor
    {
        private int _amountAvailable;

        public Transactor()
        {
            this._amountAvailable = 100;
        }


        public bool ValidateBill(int bill)
        {
            if(bill == 1 || bill == 2 || bill == 5 || bill == 10 || bill == 20 || bill == 50 || bill == 100)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool AddAmount(int amount)
        {
            if(ValidateBill(amount))
            {
                this._amountAvailable += amount;
                return true;
            }

            else 
            {
                return false;
            }
        }

        public void SubAmount(int amount)
        {
            if(ValidateBill(amount))
            {
                this._amountAvailable -= amount;
            }
        }

        public bool GetChange(int amount)
        {
            if(amount > 0)
            {
                SubAmount(amount);
                return true;
            }

            else 
            {
                return false;
            }
        }
    }
}