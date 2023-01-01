using Maui_Project_Lars_Weyen.ViewModels;

namespace Maui_Project_Lars_Weyen.Views;

public partial class TrendingView : ContentPage
{
    TrendingViewModel viewModel;

    public TrendingView(TrendingViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        this.viewModel = viewModel;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.GetGamesCommand.Execute(null);
        StartTimer();
    }
    protected override void OnDisappearing()
    {
        timer = false;
        base.OnDisappearing();
    }

    public void GoToNextSlide()
    {
        if (carouselView.Position == 2)
        {
            carouselView.Position = 0;
        }
        else
        {
            carouselView.Position++;
        }
       
    }
    private bool timer = true;
    private async void StartTimer()
    {
        while (timer)
        {
            GoToNextSlide();
            await Task.Delay(5000); // Advance to the next slide every 5 seconds
        }
    }
}