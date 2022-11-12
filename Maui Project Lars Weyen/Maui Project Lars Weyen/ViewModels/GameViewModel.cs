using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Maui_Project_Lars_Weyen.ViewModels
{
    [INotifyPropertyChanged]
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

        public GameViewModel()
        {
            SelectOverview();
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
    }
}
