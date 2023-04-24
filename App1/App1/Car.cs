using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App1
{
    public class Car
    {
        public int Rok { get; set; }
        public string Nazwa { get; set; }

        public string Zdjecie { get; set; }

        public Car(string nazwa , int rok, string zdjecie)
        {
            Nazwa = nazwa;
            Rok = rok;
            Zdjecie = zdjecie;
        }
    }
    public class CarGroup:ObservableCollection<Car>
    {
        public string title { get; set; }
        public string img { get; set; }
        public ObservableCollection<Car> CarsGroup;
        public CarGroup(string title,String img)
        {
            this.title = title;
            this.img = img;
            
        }
    }
}
