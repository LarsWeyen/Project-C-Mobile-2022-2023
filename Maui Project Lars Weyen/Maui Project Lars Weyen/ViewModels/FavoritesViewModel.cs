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

namespace Maui_Project_Lars_Weyen.ViewModels
{
    [INotifyPropertyChanged]
    public partial class FavoritesViewModel
    {
        [ObservableProperty]
        List<Game> games;
        [ObservableProperty]
        User userInfo;
        [ObservableProperty]
        bool isBusy;

        FavoritesService service;
        public FavoritesViewModel(FavoritesService service)
        {
            this.service = service;
            //Logged in user
            UserInfo = JsonConvert.DeserializeObject<User>(Preferences.Get(nameof(App.userInfo), ""));
        }
        [RelayCommand]
        private async Task GetFavorites()
        {
            IsBusy = true;
            Games = await service.GetUserFavorites(UserInfo.UserId);
            IsBusy= false;
        }
        [RelayCommand]
        async Task GoToSelectedGame(Game game)
        {
            await Shell.Current.GoToAsync($"../{nameof(GameView)}?GameID={game.id}");
        }
    }
}
