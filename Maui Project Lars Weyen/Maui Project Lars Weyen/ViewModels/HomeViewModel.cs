using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui_Project_Lars_Weyen.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Maui_Project_Lars_Weyen.ViewModels
{
    public partial class HomeViewModel
    {
        [RelayCommand]
        async Task SignOut()
        {
            if (Preferences.ContainsKey(nameof(App.userInfo)))
            {
                Preferences.Remove(nameof(App.userInfo));
            }
            await Shell.Current.GoToAsync($"//{nameof(StartView)}");
        }

        public User user { get; set; }
        

        public HomeViewModel()
        {
           
        }
        
       
        

    }
}
