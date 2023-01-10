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
using static Android.Graphics.ColorSpace;

namespace Maui_Project_Lars_Weyen.ViewModels
{
    [INotifyPropertyChanged]
    [QueryProperty("ReviewId","ReviewId")]
    public partial class ReviewViewModel
    {
        [ObservableProperty]
        int reviewId;
        [ObservableProperty]
        Review review;

        ReviewService service;
        public ReviewViewModel(ReviewService service)
        {
            this.service = service;
        }

        [RelayCommand]
        async Task GetReview()
        {
            Review = await service.GetReview(ReviewId);
        }
        [RelayCommand]
        async Task GoToUserProfile(int userId)
        {
            User UserInfo = JsonConvert.DeserializeObject<User>(Preferences.Get(nameof(App.userInfo), ""));
            //If you click on your own profile from a review you will be redirected to your own profile instead of VisitProfileView
            if (UserInfo.UserId == userId)
            {
                await Shell.Current.GoToAsync($"//{nameof(ProfileView)}");
            }
            else
            {
                await Shell.Current.GoToAsync($"{nameof(VisitProfileView)}?UserId={userId}");
            }
        }
        
    }
}
