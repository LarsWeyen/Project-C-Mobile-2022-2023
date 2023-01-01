using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui_Project_Lars_Weyen.Models;
using Maui_Project_Lars_Weyen.Services;
using Maui_Project_Lars_Weyen.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_Project_Lars_Weyen.ViewModels
{
    [INotifyPropertyChanged]
    public partial class TrendingViewModel
    {         
        public ObservableCollection<Review> CarouselGames { get; set; } = new();
        public ObservableCollection<Review> Games { get; set; } = new();

        TrendingService service;
        public TrendingViewModel(TrendingService service)
        {
            this.service = service;          
        }

        [RelayCommand]
        async Task GetGames()
        {
            CarouselGames.Clear();
            Games.Clear();
            var games = await service.GetTrendingGames();
            
            var carouselGames = games.Take(3).ToList();
            foreach (var item in carouselGames)
            {
                CarouselGames.Add(item);
            }
            var remaining = games.Skip(3).Take(games.Count());
            foreach (var item in remaining)
            {
                Games.Add(item);
            }
        }
        [RelayCommand]
        async Task GoToSelectedGame(Review game)
        {
            await Shell.Current.GoToAsync($"{nameof(GameView)}?GameID={game.GameId}");
        }
    }
}
