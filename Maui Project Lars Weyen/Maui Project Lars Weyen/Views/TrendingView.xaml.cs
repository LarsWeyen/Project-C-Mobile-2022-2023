using Maui_Project_Lars_Weyen.ViewModels;

namespace Maui_Project_Lars_Weyen.Views;

public partial class TrendingView : ContentPage
{
    TrendingViewModel viewModel;

    public TrendingView(TrendingViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        this.viewModel = viewModel;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.GetGamesCommand.Execute(null); 
    }
}