using System;

namespace VendingMachineProject
{
    class VendingMachine
    {
        private Item[, ] _shelve;
        private Display _display;
        private Keypad _keypad;
        private Transactor _transactor;

        private int _userAmount;

        public VendingMachine(Item[, ] items)
        {
            this._shelve = items;
            this._display = new Display();
            this._transactor = new Transactor();
            this._keypad =  new Keypad();
            this._userAmount = 0;
        }

        public void TurnOn()
        {
            _display.WelcomeMessage();

            int input = 0;

            while(true)
            {
                _display.DisplayMessage();
                _display.DisplayMessage("Please Enter your Choice : ");
                input = _keypad.readKey();

                switch (input)
                {
                    // Feed money
                    case 1:
                        _display.DisplayMessage("Please Enter a valid $ bill\n");
                        int bill;

                        bill = _keypad.readKey();

                        if(_transactor.AddAmount(bill))
                        {
                            this._userAmount += bill;
                            _display.DisplayMessage($"Your current balance is : {this._userAmount}\n");
                        }

                        else 
                        {
                            _display.DisplayMessage("Please Enter a valid $ bill 1, 2, 5, 10, 20, 50, 100\n");
                            _display.DisplayMessage($"Your current balance is : {this._userAmount}\n");
                        }

                        break;

                    // Product select
                    case 2:

                        int slot;
                        _display.DisplayMessage(this._shelve);
                        _display.DisplayMessage($"Your current balance is : {this._userAmount}\n");
                        _display.DisplayMessage("Please Enter product slot : ");

                        slot = _keypad.readKey();
                        BuyProduct(slot);

                        break;

                    //Change
                    case 3:
                        
                        if(_transactor.GetChange(this._userAmount))
                        {
                            _display.DisplayMessage("Please Collect the Change \n");
                            this._userAmount = 0;
                        }

                        else 
                        {
                            _display.DisplayMessage("Sorry you dont have any change \n");
                        }

                        break;

                    case 4:

                        if(this._userAmount == 0)
                        {
                            _display.DisplayMessage("Thanks for using the vending machine ! \n");
                            System.Environment.Exit(0);
                        }

                        else 
                        {
                            _display.DisplayMessage("OOps you forgot to take the change!\n");
                            _display.DisplayMessage("Please Collect the Change \n");
                            this._userAmount = 0;
                            System.Environment.Exit(0);

                        }

                        break;

                    default:
                        _display.DisplayMessage("Please Enter a valid selection");
                        break;
                }
            }
        }

        public void BuyProduct(int slot)
        {

            int column = (slot % 10) - 1;
            int row = (slot / 10) - 1;
            if ((row >= 0 && row <= 2) && (column >= 0 && column <= 3))
            {
                if (_shelve[row, column] != null)
                {
                    if (_shelve[row, column].Price <= _userAmount)
                    {
                        Console.Clear();
                        _display.DisplayMessage("You've Bought:");
                        _display.DisplayMessage(_shelve[row, column].DisplayMessage() + "\n");
                        _display.DisplayMessage("Please Pick your " + _shelve[row, column].ItemName + " from the Dispenser\n");
                        this._userAmount -= this._shelve[row, column].Price;
                        _shelve[row, column] = null;
                    }
                    else
                    {
                        _display.DisplayMessage("\nSorry You don't have Enough Balance to buy: " + _shelve[row, column].ItemName + "\n");
                    }
                }
                else
                {
                    _display.DisplayMessage("\nThe Selected Slot # is Empty\n");
                }
            }
            else
            {
                _display.DisplayMessage("\nYou've Entered an Invalid Slot Number\n");
            }
        }

    }
}