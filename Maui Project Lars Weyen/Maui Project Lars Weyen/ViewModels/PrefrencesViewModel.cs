using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui_Project_Lars_Weyen.Models;
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
    public partial class PrefrencesViewModel
    {
        [ObservableProperty]
        public User userInfo;

        [RelayCommand]
        async Task SignOut()
        {
            if (Preferences.ContainsKey(nameof(App.userInfo)))
            {
                Preferences.Remove(nameof(App.userInfo));
            }
            await Shell.Current.GoToAsync($"//{nameof(StartView)}");
        }
        [RelayCommand]
        async Task GoToChangeSettings()
        {
            await Shell.Current.GoToAsync($"{nameof(SettingsView)}");
        }
        [RelayCommand]
        public void GetUserInfo()
        {
            UserInfo = JsonConvert.DeserializeObject<User>(Preferences.Get(nameof(App.userInfo), ""));
        }
    }
}
