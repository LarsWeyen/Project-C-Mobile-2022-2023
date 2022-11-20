using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui_Project_Lars_Weyen.Models;
using Maui_Project_Lars_Weyen.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Maui_Project_Lars_Weyen.ViewModels
{
    [INotifyPropertyChanged]
    public partial class HomeViewModel
    {
        HomeService service;

        [ObservableProperty]
        List<Review> reviews;
         
        public HomeViewModel(HomeService service)
        {
            this.service = service;
            GetReviews();
        }

        [RelayCommand]
        async Task GetReviews()
        {
            Reviews = await service.GetReviews("Rating","desc");
        }

        [RelayCommand]
        async Task SignOut()
        {
            if (Preferences.ContainsKey(nameof(App.userInfo)))
            {
                Preferences.Remove(nameof(App.userInfo));
            }
            await Shell.Current.GoToAsync($"//{nameof(StartView)}");
        }

    }
}
