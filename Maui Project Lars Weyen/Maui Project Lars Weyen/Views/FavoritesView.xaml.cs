using AndroidX.Lifecycle;
using Maui_Project_Lars_Weyen.ViewModels;

namespace Maui_Project_Lars_Weyen.Views;

public partial class FavoritesView : ContentPage
{
    FavoritesViewModel viewModel;
	public FavoritesView(FavoritesViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
        this.viewModel = viewModel;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.GetFavoritesCommand.Execute(null);
    }
}