using Maui_Project_Lars_Weyen.Models;
using Maui_Project_Lars_Weyen.ViewModels;
using Newtonsoft.Json;

namespace Maui_Project_Lars_Weyen.Views;

public partial class HomeView : ContentPage
{
	

    public HomeView(HomeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;	
	}
	protected override void OnAppearing()
	{
		base.OnAppearing();
		
	}
}