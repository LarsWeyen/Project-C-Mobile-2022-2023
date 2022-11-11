using AndroidX.Lifecycle;
using Maui_Project_Lars_Weyen.ViewModels;

namespace Maui_Project_Lars_Weyen.Views;

public partial class SearchView : ContentPage
{
    SearchViewModel viewModel;

    public SearchView(SearchViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
        this.viewModel = viewModel;
	}

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        viewModel.SearchGameCommand.Execute(e);

    }
}