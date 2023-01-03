using AndroidX.Lifecycle;
using Maui_Project_Lars_Weyen.ViewModels;

namespace Maui_Project_Lars_Weyen.Views;

public partial class VisitProfileView : ContentPage
{
	VisitProfileViewModel viewModel;
	public VisitProfileView(VisitProfileViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		this.viewModel = viewModel;
	}
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
		viewModel.GetUserProfileCommand.Execute(null);
		viewModel.GetReviewsCommand.Execute(null);
		viewModel.CheckLikedCommand.Execute(null);
    }
}