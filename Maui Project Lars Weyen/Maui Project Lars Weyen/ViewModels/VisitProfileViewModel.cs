using Android.Hardware;
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
    [QueryProperty(nameof(UserId),"UserId")]
    public partial class VisitProfileViewModel
    {
        [ObservableProperty]
        int userId;
        [ObservableProperty]
        User userInfo;
        [ObservableProperty]
        List<Review> reviews;
        [ObservableProperty]
        string thumbIcon = "thumbs_up.svg";
        [ObservableProperty]
        string text = "Like Profile";
       
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
        [RelayCommand]
        async Task LikeProfile()
        {
            var loggedInUser = JsonConvert.DeserializeObject<User>(Preferences.Get(nameof(App.userInfo), ""));
            var postData = new Dictionary<string, object>()
            {
                {"ProfileId",UserInfo.UserId },
                {"UserId",loggedInUser.UserId }
            };
            var response = await service.AddToOrRemoveProfileLike(postData);
            var responseString = await response.Content.ReadAsStringAsync();
            //Check if logged in user has liked this profile or not
            if (responseString=="Item added")
            {
               await service.PutProfileLike(true,UserId);
            }
            else
            {
                await service.PutProfileLike(false, UserId);
            }
            await GetUserProfile();
            await CheckLiked();    
        }
        [RelayCommand]
        async Task CheckLiked()
        {
            var loggedInUser = JsonConvert.DeserializeObject<User>(Preferences.Get(nameof(App.userInfo), ""));
            string response = await service.SearchForProfileLike(UserId, loggedInUser.UserId);
            if (response =="NotLiked")
            {
                ThumbIcon = "thumbs_up.svg";
                Text = "Like Profile";
            }
            else
            {
                ThumbIcon = "remove_icon.svg";
                Text = "Remove Like";
            }
        }
        [RelayCommand]
        async Task OpenReview(Review review)
        {
            await Shell.Current.GoToAsync($"{nameof(ReviewView)}?ReviewId={review.ReviewId}");
        }
    }
}
