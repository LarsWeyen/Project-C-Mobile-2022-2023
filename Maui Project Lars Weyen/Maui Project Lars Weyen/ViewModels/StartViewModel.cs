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
    public partial class StartViewModel
    {
        LoginAndRegisterService service;
        HttpClient client;
        public StartViewModel(LoginAndRegisterService service)
        {
            this.service = service;
            this.client = new HttpClient();
            ProfilePIC = new Image();
            ProfilePIC.Source ="test.jpg";
            CheckUserLogin();
        }

        private async void CheckUserLogin()
        {
            string userInfo = Preferences.Get(nameof(App.userInfo), null);

            if (string.IsNullOrWhiteSpace(userInfo))
            {
                return;
            }
            else
            {              
                await Shell.Current.GoToAsync($"//{nameof(HomeView)}");
            }
        }

        [RelayCommand]
        async Task GoToSignInPage()
        {
            await Shell.Current.GoToAsync($"../{nameof(LoginView)}");
        }
        [RelayCommand]
        async Task GoToNextRegisterPage()
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(username))
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(username))
            {
                return ;
            }
            else
            {
                await Shell.Current.GoToAsync($"{nameof(RegisterImageView)}");
            }
            
        }

        [RelayCommand]
        async Task GoToRegisterPage()
        {
            await Shell.Current.GoToAsync($"../{nameof(RegisterView)}");
        }

        public string email { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public string profilePicUrl { get; set; }
       
        [RelayCommand]
        async Task SignIn()
        {
           
            
            var postData = new Dictionary<string, object>()
            {
                {"Email",email },
                {"Password",password }
            };
            var content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://192.168.0.145:7777/api/SignIn", content);     
            var responseString = await response.Content.ReadAsStringAsync();
            if (responseString == "User not found")
            {
                return;
            }
            if (response.IsSuccessStatusCode)
            {
                if (Preferences.ContainsKey(nameof(App.userInfo)))
                {
                    Preferences.Remove(nameof(App.userInfo));
                }

                Preferences.Set(nameof(App.userInfo),responseString);
                await Shell.Current.GoToAsync($"//{nameof(HomeView)}");
            }
            
            
        }
        [RelayCommand]
        async Task Register()
        {
            var postData = new Dictionary<string, object>()
            {
                {"Username",username },
                {"Email",email },
                {"Password",password },
                {"ProfilePicUrl",profilePicUrl }
            };
            var content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://192.168.0.145:7777/api/Register", content);
            var responseString = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                if (Preferences.ContainsKey(nameof(App.userInfo)))
                {
                    Preferences.Remove(nameof(App.userInfo));
                }

                Preferences.Set(nameof(App.userInfo), responseString);
                await Shell.Current.GoToAsync($"//{nameof(HomeView)}");
            }
            
        }

        [ObservableProperty]
        private Image _profilePic;

        public Image ProfilePIC
        {
            get => _profilePic;
            set
            {
                SetProperty(ref _profilePic, value);
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
    }
}
