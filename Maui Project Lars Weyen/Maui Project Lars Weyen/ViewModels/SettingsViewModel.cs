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
    public partial class SettingsViewModel
    {
        [ObservableProperty]
        private User userInfo;
        [ObservableProperty]
        private Image _profilePic;

        [ObservableProperty]
        private string username;
        [ObservableProperty]
        private string email;
        [ObservableProperty]
        private string password;
        [ObservableProperty]
        private string bio;

        public string profilePicUrl;

        public Image ProfilePIC
        {
            get => _profilePic;
            set
            {
                SetProperty(ref _profilePic, value);
            }
        }

        SettingsService settingsService;
        public SettingsViewModel(SettingsService settingsService)
        { 
            this.settingsService = settingsService;
            GetProfile();
            ProfilePIC = new Image();
            
        }

        private async void GetProfile()
        {
            if (UserInfo is null)
            {
                UserInfo = await settingsService.GetUserByEmail();
                ProfilePIC.Source = UserInfo.ProfilePicUrl;
                profilePicUrl = UserInfo.ProfilePicUrl;
                Username = UserInfo.Username;
                Email = UserInfo.Email;
                Password = UserInfo.Password;
                Bio = UserInfo.Bio;
            }
        }
        string imageUrl;
        [RelayCommand]
        async Task ChooseImage()
        {

            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Choose an Image",
                FileTypes = FilePickerFileType.Images,
            });
            if (result == null)
                return;

            var stream = await result.OpenReadAsync();
            ProfilePIC.Source = ImageSource.FromStream(() => stream);

            byte[] bytes = File.ReadAllBytes(result.FullPath);
            var base64 = Convert.ToBase64String(bytes);

            if (result.ContentType == "image/jpeg")
            {
                imageUrl = "data:image/jpeg;base64," + base64;
            }
            if (result.ContentType == "image/png")
            {
                imageUrl = "data:image/png;base64," + base64;
            }
            profilePicUrl = imageUrl;
        }

        

        [RelayCommand]
        async Task SaveSettings()
        {
            Dictionary<string, object> postData;
            if (Email != UserInfo.Email)
            {
                postData = new Dictionary<string, object>()
            {
                {"UserId",UserInfo.UserId },
                {"Username",Username },
                {"Email",Email},
                {"ProfilePicUrl",profilePicUrl },
                {"Password",Password },
                {"Bio",Bio },             
            };
            }
            else
            {
                postData = new Dictionary<string, object>()
            {
                {"UserId",UserInfo.UserId.ToString() },               
                {"Username",Username },
                {"Bio",Bio },
                {"Email","" },
                {"Password",Password },
                {"ProfilePicUrl",profilePicUrl }           
            };
            }
            
            HttpResponseMessage response = await settingsService.UpdateSettings(postData);
            var responseString = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                if (Preferences.ContainsKey(nameof(App.userInfo)))
                {
                    Preferences.Remove(nameof(App.userInfo));
                }

                Preferences.Set(nameof(App.userInfo), responseString);
            }
        }
    }
}
