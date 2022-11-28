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
        [ObservableProperty]
        Game test;

        public ObservableCollection<Game> Games { get; set; } = new();

        TrendingService service;
        public TrendingViewModel(TrendingService service)
        {
            this.service = service;          
        }

        [RelayCommand]
        async Task GetGames()
        {
            var games = await service.GetGames();
            foreach (var game in games)
            {
                Games.Add(game);
            }
            
        }
    }
}
