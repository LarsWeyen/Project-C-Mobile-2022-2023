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
    public partial class TrendingViewModel
    {
        [ObservableProperty]
        List<Game> carouselGames;
        [ObservableProperty]
        Game test;

        TrendingService service;
        public TrendingViewModel(TrendingService service)
        {
            this.service = service;          
        }

        [RelayCommand]
        async Task GetGames()
        {
            carouselGames = await service.GetGames();
            
        }    
    }
}
