using Maui_Project_Lars_Weyen.ViewModels;

namespace Maui_Project_Lars_Weyen.Views;

public partial class ProfileView : ContentPage
{
    ProfileViewModel viewModel;

    public ProfileView(ProfileViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        this.viewModel = viewModel;
	}
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        viewModel.GetReviewsCommand.Execute(null);
        viewModel.GetProfileCommand.Execute(null);
    }
}