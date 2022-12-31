using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui_Project_Lars_Weyen.Models;
using Maui_Project_Lars_Weyen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Graphics.ColorSpace;

namespace Maui_Project_Lars_Weyen.ViewModels
{
    [INotifyPropertyChanged]
    [QueryProperty("ReviewId","ReviewId")]
    public partial class ReviewViewModel
    {
        [ObservableProperty]
        int reviewId;
        [ObservableProperty]
        Review review;

        ReviewService service;
        public ReviewViewModel(ReviewService service)
        {
            this.service = service;
        }

        [RelayCommand]
        async Task GetReview()
        {
            Review = await service.GetReview(ReviewId);
        }
    }
}
