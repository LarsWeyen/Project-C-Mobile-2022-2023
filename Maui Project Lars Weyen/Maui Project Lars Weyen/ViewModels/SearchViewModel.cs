using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui_Project_Lars_Weyen.Models;
using Maui_Project_Lars_Weyen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_Project_Lars_Weyen.ViewModels
{
    [INotifyPropertyChanged]
    public partial class SearchViewModel
    {
        [ObservableProperty]
        List<Game> games;
        [ObservableProperty]
        string entrySearch;

        SearchService searchService;
        public SearchViewModel(SearchService searchService)
        {
            this.searchService = searchService;
        }

        [RelayCommand]
        async Task SearchGame()
        {
            Games = await searchService.SearchGames(EntrySearch);
        }
    }
}
