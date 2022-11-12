using Maui_Project_Lars_Weyen.ViewModels;

namespace Maui_Project_Lars_Weyen.Views;

public partial class GameView : ContentPage
{
	public GameView(GameViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}