﻿using CommunityToolkit.Mvvm.ComponentModel;
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
           Reviews= new List<Review>();
        }
        [RelayCommand]
        private async void GetProfile()
        {          
             UserInfo = JsonConvert.DeserializeObject<User>(Preferences.Get(nameof(App.userInfo), ""));
        }

        [RelayCommand]
        async Task GoToAddReview()
        {
            await Shell.Current.GoToAsync($"{nameof(AddReviewView)}");
        }

        [RelayCommand]
        private async Task GetReviews()
        {
            Reviews.Clear();
           Reviews = await service.GetUserReviews();
        }

        [RelayCommand]
        async Task GoToSelectedGame(Review review)
        {
            await Shell.Current.GoToAsync($"{nameof(GameView)}?GameID={review.GameId}");
        }
        [RelayCommand]
        async Task OpenReview(Review review)
        {
            await Shell.Current.GoToAsync($"{nameof(ReviewView)}?ReviewId={review.ReviewId}");
        }
    }
}
