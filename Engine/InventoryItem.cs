﻿using System.ComponentModel;

namespace Engine
{
    public class InventoryItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Item _details;
        private int _quantity;

        public Item Details
        {
            get { return _details; }
            set
            {
                _details = value;
                OnPropertyChanged("Details");
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
                OnPropertyChanged("Description");
            }
        }

        public int ItemID
        {
            get { return Details.ID; }
        }

        public int Price
        {
            get { return Details.Price; }
        }

        public InventoryItem(Item details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }

        public string Description
        {
            get { return Quantity > 1 ? Details.NamePlural : Details.Name; }
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
