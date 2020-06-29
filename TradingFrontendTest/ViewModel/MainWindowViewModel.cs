using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TradingFrontendTest.Model;

namespace TradingFrontendTest.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<Product> products;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Product> Products
        {
            get
            {
                return products;
            }

            set
            {
                products = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Raises OnPropertychangedEvent when property changes
        /// </summary>
        /// <param name="name">String representing the property name</param>
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

 
        public MainWindowViewModel()
        {
           
            products = GetData();
        }

        /// <summary>
        /// Simulates data retrieval from a repository
        /// </summary>
        private ObservableCollection<Product> GetData()
        {
            return new ObservableCollection<Product>()
            {
                new Product("Product1"),
                new Product("Product1"),
                new Product("Product1"),
                new Product("Product2"),
                new Product("Product3")
            };
        }



    }
}
