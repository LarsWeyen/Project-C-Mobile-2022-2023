using Maui_Project_Lars_Weyen.ViewModels;

namespace Maui_Project_Lars_Weyen.Views;

public partial class RegisterView : ContentPage
{
	public RegisterView(StartViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}