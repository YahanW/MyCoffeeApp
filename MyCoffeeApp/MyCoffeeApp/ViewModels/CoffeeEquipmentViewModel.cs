using MvvmHelpers;
using MvvmHelpers.Commands;
using MyCoffeeApp.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyCoffeeApp.ViewModels
{
    public class CoffeeEquipmentViewModel : ViewModelBase
    {
        public ObservableCollection<Coffee> Coffee { get; set; }
        public ObservableCollection<Grouping<string, Coffee>> CoffeeGroups { get; set; }   
        public AsyncCommand RefreshCommand { get; }

        public AsyncCommand<Coffee> FavoriteCommand { get; }
        public CoffeeEquipmentViewModel() 
        {
            //IncreaseCount = new Command(OnIncrease);
            Title = "Coffee Equipment";

            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroups = new ObservableCollection<Grouping<string, Coffee>>();

            var image = "https://images.pexels.com/photos/16085964/pexels-photo-16085964.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1";
            
            Coffee.Add(new Models.Coffee { Roaster = "Villino", Name = "Cranberry", Image = image });
            Coffee.Add(new Models.Coffee { Roaster = "Platypus", Name = "Chocolate", Image = image });
            Coffee.Add(new Models.Coffee { Roaster = "Starbucks", Name = "Burnt", Image = image });
            Coffee.Add(new Models.Coffee { Roaster = "Maxie", Name = "DaeJong Jige", Image = image });
            Coffee.Add(new Models.Coffee { Roaster = "Starbucks", Name = "Fruity", Image = image });
            Coffee.Add(new Models.Coffee { Roaster = "Starbucks", Name = "IDK", Image = image });

            CoffeeGroups.Add(new Grouping<string, Coffee>("Blue", new[] { Coffee[2] }));
            CoffeeGroups.Add(new Grouping<string, Coffee>("Villino", Coffee.Take(2)));

            RefreshCommand = new AsyncCommand(Refresh);
            FavoriteCommand = new AsyncCommand<Coffee>(Favorite);
        }
        Coffee previouslySelected;
        Coffee selectedCoffee;
        public Coffee SelectedCoffee
        {
            get => selectedCoffee;
            set
            {
                if(value != null)
                {
                    Application.Current.MainPage.DisplayAlert("Selected", value.Name, "OK");
                    value = null;
                }

                selectedCoffee = value;
                OnPropertyChanged();
            }
        }

        async Task Favorite(Coffee coffee)
        {
            if (coffee == null)
                return;

            await Application.Current.MainPage.DisplayAlert("Added to Favorite", coffee.Name, "OK");

        }

        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            IsBusy = false;
        }
       
    }
}
