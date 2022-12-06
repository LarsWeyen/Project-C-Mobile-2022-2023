using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui_Project_Lars_Weyen.Models;
using Maui_Project_Lars_Weyen.Services;
using Maui_Project_Lars_Weyen.Views;
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
            Reviews = await service.GetReviews("ReviewId","desc");
        }

        [RelayCommand]
        async Task OpenPopUp()
        {
            var result = await App.Current.MainPage.ShowPopupAsync(new SortingPopUp());
            var sort = (Sorting)result;
            Reviews = await service.GetReviews(sort.OrderBy,sort.SortBy);
        }   
    }
}
