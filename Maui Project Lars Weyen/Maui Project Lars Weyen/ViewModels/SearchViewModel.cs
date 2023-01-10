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
    public partial class SearchViewModel
    {
        [ObservableProperty]
        List<Game> games;
        [ObservableProperty]
        string entrySearch;
        [ObservableProperty]
        List<Genre> genre;
        [ObservableProperty]
        List<Genre> selectedGenres;

        SearchService searchService;
        public SearchViewModel(SearchService searchService)
        {
            this.searchService = searchService;
            SelectedGenres = new List<Genre>();
            GetGenre();
        }

        [RelayCommand]
        async Task SearchGame()
        {
            Games = await searchService.SearchGames(EntrySearch);
        }

        [RelayCommand]
        async Task GetGenre()
        {
            Genre = await searchService.GetGenres();
        }
        [RelayCommand]
        async Task SelectedGenre(Genre genre)
        {

            List<string> genresList = new List<string>();
            if (SelectedGenres.Contains(genre))
            {
                string colorHex = "#868686";
                genre.selectedBorder = Color.FromArgb(colorHex);
                genre.selectedLabel = Colors.White;
                SelectedGenres.Remove(genre);
                foreach (var item in SelectedGenres)
                {
                    genresList.Add($"\"{item.name}\"");
                }
            }
            else
            {
                string colorHex = "#9CD1C0";
                genre.selectedBorder = Color.FromArgb(colorHex);
                genre.selectedLabel = Color.FromArgb(colorHex);
                SelectedGenres.Add(genre);
                
                foreach (var item in SelectedGenres)
                {
                    genresList.Add($"\"{item.name}\"");
                }
                
            }
            //genres = "Shooter","Survival",...
            string genres = String.Join(",", genresList);
            
            Games = await searchService.SearchByGenre(genres);
        }


        [RelayCommand]
        async Task GoToSelectedGame(Game game)
        {
            await Shell.Current.GoToAsync($"{nameof(GameView)}?GameID={game.id}");
        }
    }
}
