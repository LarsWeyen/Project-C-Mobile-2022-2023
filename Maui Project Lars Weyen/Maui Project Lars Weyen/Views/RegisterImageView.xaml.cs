using Maui_Project_Lars_Weyen.ViewModels;

namespace Maui_Project_Lars_Weyen.Views;

public partial class RegisterImageView : ContentPage
{
	public RegisterImageView(StartViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	
}