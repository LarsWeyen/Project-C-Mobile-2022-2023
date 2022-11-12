using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui_Project_Lars_Weyen.Models;
using Maui_Project_Lars_Weyen.Services;
using Maui_Project_Lars_Weyen.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Maui_Project_Lars_Weyen.ViewModels
{
    [INotifyPropertyChanged]
    [QueryProperty(nameof(GameId), "GameID")]
    public partial class GameViewModel
    {
       
        [ObservableProperty]
        Color overview;
        [ObservableProperty]
        Color reviews;
        [ObservableProperty]
        Color overviewLabel;
        [ObservableProperty]
        Color reviewsLabel;
        [ObservableProperty]
        Game game;
        [ObservableProperty]
        int gameId;

        GameService service;
        public GameViewModel(GameService service)
        {
            SelectOverview();
            this.service = service;
            GetGame();
        }

        [RelayCommand]
        private void SelectOverview()
        {
            string selected = "#9CD1C0";          
            Overview = Color.FromArgb(selected);
            Reviews = Colors.Black;
            ReviewsLabel = Colors.White;
            OverviewLabel = Color.FromArgb(selected); 
        }
        [RelayCommand]
        private void SelectReviews()
        {
            string selected = "#9CD1C0";
            Overview = Colors.Black;
            Reviews = Color.FromArgb(selected);
            OverviewLabel = Colors.White;
            ReviewsLabel = Color.FromArgb(selected);
        }

        [RelayCommand]
        async Task GetGame()
        {
             Game = await service.GetGame(GameId);
        }

        [RelayCommand]
        async Task GoToSelectedGame(SimilarGame game)
        {
            await Shell.Current.GoToAsync($"{nameof(GameView)}?GameID={game.id}");
        }
    }
}
