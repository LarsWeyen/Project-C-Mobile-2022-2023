using Maui_Project_Lars_Weyen.Models;
using Maui_Project_Lars_Weyen.ViewModels;

namespace Maui_Project_Lars_Weyen.Views;

public partial class AddReviewView : ContentPage
{
	AddReviewModel viewModel;
	public AddReviewView(AddReviewModel viewModel)
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