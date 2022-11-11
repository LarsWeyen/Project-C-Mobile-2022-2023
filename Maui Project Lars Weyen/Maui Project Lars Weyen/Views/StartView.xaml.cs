using Maui_Project_Lars_Weyen.ViewModels;
using Maui_Project_Lars_Weyen.Views;

namespace Maui_Project_Lars_Weyen;

public partial class StartView : ContentPage
{
	public StartView(StartViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	private void btnRegister_Clicked(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync($"{nameof(RegisterView)}");
    }

	private void btnSignIn_Clicked(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync($"{nameof(LoginView)}");
    }
}

