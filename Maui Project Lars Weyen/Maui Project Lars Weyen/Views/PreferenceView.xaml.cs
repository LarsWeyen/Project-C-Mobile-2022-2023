using AndroidX.Lifecycle;
using Maui_Project_Lars_Weyen.ViewModels;

namespace Maui_Project_Lars_Weyen.Views;

public partial class PreferenceView : ContentPage
{
    PrefrencesViewModel viewModel;
    public PreferenceView(PrefrencesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        this.viewModel = viewModel;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.GetUserInfoCommand.Execute(null);
    }

    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
        if (viewModel != null)
        {
            viewModel.SwitchDarkmodeCommand.Execute(null);
        }    
    }
}