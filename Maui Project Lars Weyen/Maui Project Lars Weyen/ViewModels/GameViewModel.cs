using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui_Project_Lars_Weyen.Models;
using Maui_Project_Lars_Weyen.Services;
using Maui_Project_Lars_Weyen.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Java.Interop.JniEnvironment;


namespace Maui_Project_Lars_Weyen.ViewModels
{
    [INotifyPropertyChanged]
    [QueryProperty(nameof(GameId), "GameID")]
    public partial class GameViewModel
    {
       
        [ObservableProperty]
        Color overview;
        [ObservableProperty]
        Color reviewsColor;
        [ObservableProperty]
        Color overviewLabel;
        [ObservableProperty]
        Color reviewsLabel;
        [ObservableProperty]
        Game game;
        [ObservableProperty]
        int gameId;
        [ObservableProperty]
        bool overviewVisible;
        [ObservableProperty]
        bool reviewsVisible;
        [ObservableProperty]
        List<Review> reviews;
        [ObservableProperty]
        Color heartFill;
        [ObservableProperty]
        User userInfo;

        GameService service;
        public GameViewModel(GameService service)
        {
            SelectOverview();
            this.service = service;
            GetProfile();
        }

        [RelayCommand]
        private void SelectOverview()
        {
            OverviewVisible = true;
            ReviewsVisible = false;
            string selected = "#9CD1C0";          
            Overview = Color.FromArgb(selected);
            ReviewsColor = Colors.Black;
            ReviewsLabel = Colors.White;
            OverviewLabel = Color.FromArgb(selected); 
        }
        [RelayCommand]
        private void SelectReviews()
        {
            OverviewVisible = false;
            ReviewsVisible = true;
            string selected = "#9CD1C0";
            Overview = Colors.Black;
            ReviewsColor = Color.FromArgb(selected);
            OverviewLabel = Colors.White;
            ReviewsLabel = Color.FromArgb(selected);
            GetReviews();
        }

        [RelayCommand]
        async Task GetGame()
        {
             Game = await service.GetGame(GameId);
        }

        [RelayCommand]
        async Task GetReviews()
        {
            Reviews = await service.GetGameReviews(GameId);
        }

        [RelayCommand]
        async Task GoToSelectedGame(SimilarGame game)
        {
            await Shell.Current.GoToAsync($"{nameof(GameView)}?GameID={game.id}");
        }

        [RelayCommand]
        async Task GoToUserProfile(Review review)
        {
            if (userInfo.UserId == review.UserId)
            {
                await Shell.Current.GoToAsync($"{nameof(ProfileView)}");
            }
            else
            {
                await Shell.Current.GoToAsync($"{nameof(VisitProfileView)}?UserId={review.UserId}");
            }
        }

        [RelayCommand]
        async Task AddToFavorites()
        {
            var postData = new Dictionary<string, object>()
            {
                {"UserId",UserInfo.UserId },
                {"GameId",GameId }
            };
            var response = await service.AddToOrRemoveFromFavorites(postData);
            var responseString = await response.Content.ReadAsStringAsync();
            if (responseString == "Item added")
            {
                string colorHex = "#9CD1C0";
                HeartFill = Color.FromArgb(colorHex);
            }
            else
            {
                HeartFill = Colors.Transparent;
            }

        }
        [RelayCommand]
        private void GetProfile()
        {
            UserInfo = JsonConvert.DeserializeObject<User>(Preferences.Get(nameof(App.userInfo), ""));
        }
        [RelayCommand]
        private async Task CheckIfFavorited()
        {
            var response = await service.SearchForFavorite(UserInfo.UserId,GameId);
            if (response == "IsNotFavorited")
            {
                HeartFill = Colors.Transparent;
            }
            else
            {
                string colorHex = "#9CD1C0";
                HeartFill = Color.FromArgb(colorHex);
            }
        }
    }
}
