using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui_Project_Lars_Weyen.Models;
using Maui_Project_Lars_Weyen.Services;
using Maui_Project_Lars_Weyen.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_Project_Lars_Weyen.ViewModels
{
    [INotifyPropertyChanged]
    public partial class ProfileViewModel
    {

        ProfileService service;

        [ObservableProperty]
        private User userInfo;
        [ObservableProperty]
        private List<Review> reviews;

        public ProfileViewModel(ProfileService service)
        {
            this.service = service;
            GetProfile();
            GetReviews();
        }
        private async void GetProfile()
        {
            UserInfo = await service.GetUserByEmail();
        }

        [RelayCommand]
        async Task GoToAddReview()
        {
            await Shell.Current.GoToAsync($"{nameof(AddReviewView)}");
        }

        [RelayCommand]
        private async void GetReviews()
        {
           Reviews = await service.GetUserReviews();
        }
    }
}
