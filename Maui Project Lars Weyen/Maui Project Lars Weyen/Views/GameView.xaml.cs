using AndroidX.Lifecycle;
using Maui_Project_Lars_Weyen.ViewModels;

namespace Maui_Project_Lars_Weyen.Views;

public partial class GameView : ContentPage
{
    GameViewModel viewModel;

    public GameView(GameViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        this.viewModel = viewModel;
	}
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        viewModel.GetGameCommand.Execute(null);
        viewModel.CheckIfFavoritedCommand.Execute(null);
    }
}