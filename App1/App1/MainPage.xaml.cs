using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<CarGroup> CarGroups { get; set; }
        public MainPage()
        {
            InitializeComponent();
            CarGroups = new ObservableCollection<CarGroup>()
            {
                new CarGroup("Osobowe","osobowe.jpg")
                {
                    new Car("Jaguar",2020,"jaguar.png"),
                    new Car("Maserati",2010,"maserati.png")
                },
                new CarGroup("Ciezarowe", "ciezarowe.png")
                {
                    new Car("MAN TGX",2010,"mantgx.jfif"),
                }
            };
            
            CarItemsListView.ItemsSource =CarGroups;

        }

        /*
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //var searchResult = cars.Where(car => car.Nazwa.ToLower().Contains(e.NewTextValue.ToLower()));
            //var searchResult = cars.Where(car => car.Nazwa.ToLower().StartsWith(e.NewTextValue.ToLower()));
            //CarItemsListView.ItemsSource = searchResult;
            ObservableCollection<Car> cars2 = new ObservableCollection<Car>();
            foreach (var car in CarGroups) 
            {
                if(car.CarsGroup.Nazwa.ToLower().StartsWith(e.NewTextValue.ToLower()))
                {
                    cars2.Add(car);
                }
            }
            /*
            foreach (var car in cars)
            {
                if (car.Nazwa.ToLower().Contains(e.NewTextValue.ToLower()))
                {
                    cars2.Add(car);
                }
            }
            
            CarItemsListView.ItemsSource = cars2;
        }
        */

        private void Button_Clicked(object sender, EventArgs e)
        {
            var senderBindingContext = ((Button)sender).BindingContext;
            var CarGroups = (Car)senderBindingContext;
            DisplayAlert("Szczegóły samochodu", CarGroups.Nazwa, "ok");
        }

        private void itemtap(object sender, ItemTappedEventArgs e)
        {
            var car=(Car)e.Item;
            DisplayAlert("Szczegóły samochodu(Tap)", car.Nazwa, "ok");
        }

        private void MenuItem_Details(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var car = menuItem.CommandParameter as Car;
            DisplayAlert("Szczegóły samochodu", car.Nazwa, "ok");
        }

        private void MenuItem_Delete(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var car = menuItem.CommandParameter as Car;
            foreach (CarGroup group in CarGroups)
            {
                if(group.Contains(car))
                    group.Remove(car);
            }
        }

        private void itemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var car = (Car)e.SelectedItem;
            DisplayAlert("Szczegóły samochodu(Selected)", car.Nazwa, "ok");
        }
    }
}
