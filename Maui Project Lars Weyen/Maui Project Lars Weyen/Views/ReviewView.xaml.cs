using Maui_Project_Lars_Weyen.ViewModels;

namespace Maui_Project_Lars_Weyen.Views;

public partial class ReviewView : ContentPage
{
	ReviewViewModel viewModel;
	public ReviewView(ReviewViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		this.viewModel= viewModel;
	}
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
		viewModel.GetReviewCommand.Execute(null);
    }
}