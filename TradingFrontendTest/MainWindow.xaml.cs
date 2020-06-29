using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using TradingFrontendTest.Model;
using TradingFrontendTest.ViewModel;

namespace TradingFrontendTest
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel mWVM = new MainWindowViewModel();
        private static Timer timer;

        public MainWindow()
        {
           
            InitializeComponent();

            dg1.ItemsSource = mWVM.Products;

            ListCollectionView coll = new ListCollectionView(mWVM.Products);
            coll.GroupDescriptions.Add(new PropertyGroupDescription("Group"));
            dg2.ItemsSource = coll;

            SetTimer();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           mWVM.Products.Add(new Product("producto añadido"));
        }

        private void SetTimer()
        {
            timer = new Timer(5000);
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            for (int i = 0; i < mWVM.Products.Count; i++)
            {
                for (int j = 0; j < mWVM.Products[i].BaseValues.Count; j++)
                {
                    Console.WriteLine("Antes del cambio: " +i+"-"+j+": " + mWVM.Products[i].BaseValues[j]);
                    mWVM.Products[i].BaseValues[j] = Product.GenerateRandomNumberBetween(-99.99, 99.99);
                    Console.WriteLine("Despues del cambio: " + mWVM.Products[i].BaseValues[j]);
                }
             
            }
            Application.Current.Dispatcher.Invoke(new Action(() => { 
                dg1.Items.Refresh(); 
            }));

           
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
