using Maui_Project_Lars_Weyen.ViewModels;

namespace Maui_Project_Lars_Weyen.Views;

public partial class LoginView : ContentPage
{
	public LoginView(StartViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}