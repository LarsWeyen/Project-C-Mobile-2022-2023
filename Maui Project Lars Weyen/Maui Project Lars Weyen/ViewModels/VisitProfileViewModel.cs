using Android.Hardware;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui_Project_Lars_Weyen.Models;
using Maui_Project_Lars_Weyen.Services;
using Maui_Project_Lars_Weyen.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_Project_Lars_Weyen.ViewModels
{
    [INotifyPropertyChanged]
    [QueryProperty(nameof(UserId),"UserId")]
    public partial class VisitProfileViewModel
    {
        [ObservableProperty]
        int userId;
        [ObservableProperty]
        User userInfo;
        [ObservableProperty]
        List<Review> reviews;

        VisitUserProfileService service;
        public VisitProfileViewModel(VisitUserProfileService service)
        {
            this.service = service;
            
        }
        [RelayCommand]
        async Task GetUserProfile()
        {
            UserInfo = await service.GetUserById(UserId);
        }

        [RelayCommand]
        private async Task GetReviews()
        {         
            Reviews = await service.GetUserReviews(UserId);
        }
        [RelayCommand]
        async Task GoToSelectedGame(Review review)
        {
            await Shell.Current.GoToAsync($"{nameof(GameView)}?GameID={review.GameId}");
        }
    }
}
