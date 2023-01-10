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
using static Android.Provider.DocumentsContract;
using static System.Net.Mime.MediaTypeNames;

namespace Maui_Project_Lars_Weyen.ViewModels
{
    [INotifyPropertyChanged]
    public partial class AddReviewModel
    {      
        [ObservableProperty]
        List<int> numbers;
        [ObservableProperty]
        string entrySearch;
        [ObservableProperty]
        List<Game> games;
        [ObservableProperty]
        Game selectedGame;
        [ObservableProperty]
        bool imageVisable;
        [ObservableProperty]
        bool collectionVisable = true;
        [ObservableProperty]
        string reviewDescription;
        [ObservableProperty]
        int selectedNumber;

        AddReviewService reviewService;
        public AddReviewModel(AddReviewService reviewService)
        {
            FillComboBox();       
            this.reviewService = reviewService;
        }

        [RelayCommand]
        async Task SearchGame()
        {
            ImageVisable = false;
            CollectionVisable = true;

            Games = await reviewService.SearchGames(EntrySearch);
        }

        [RelayCommand]
        private void SelectGame(Game game)
        {
            CollectionVisable = false;
            ImageVisable = true;
            SelectedGame = game;
        }

        [RelayCommand]
        async Task AddReview()
        {
            if (SelectedGame is null)
                return;

            var loggedInUser = JsonConvert.DeserializeObject<User>(Preferences.Get(nameof(App.userInfo), ""));
            var postData = new Dictionary<string, object>()
            {
                {"ReviewDescription",ReviewDescription },
                {"GameImageId",SelectedGame.cover.image_id },
                {"GameId",SelectedGame.id },
                {"GameNaam",SelectedGame.name },
                {"Rating",SelectedNumber },
                {"UserId",loggedInUser.UserId }
            };
            var response = await reviewService.AddReview(postData);
            if (response.IsSuccessStatusCode)
            {
                await Shell.Current.GoToAsync($"..");
                
            }
        }

        public void FillComboBox()
        {
            numbers = new List<int>
            {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10
            };
        }
    }
}
