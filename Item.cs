using System;

namespace VendingMachineProject
{
    abstract class Item
    {
        // private members
        private string _itemName;
        private int _price;
        private readonly string _type;

        public string ItemName
        {
            get
            {
                return this._itemName;
            }
        }

        public int Price
        {
            get
            {
                return this._price;
            }
        }

        public string Type
        {
            get
            {
                return this._type;
            }
        }

        public Item(string name, int price, string type)
        {
            this._itemName = name;
            this._price = price;
            this._type = type;
        }

        public abstract string DisplayMessage();

    }
}