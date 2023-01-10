using CommunityToolkit.Maui;
using Maui_Project_Lars_Weyen.Services;
using Maui_Project_Lars_Weyen.ViewModels;
using Maui_Project_Lars_Weyen.Views;
using Syncfusion.Maui.Core.Hosting;
using Syncfusion.Maui.ListView.Hosting;

namespace Maui_Project_Lars_Weyen;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{

        var builder = MauiApp.CreateBuilder();      
        builder
			.UseMauiApp<App>()
			.ConfigureSyncfusionCore()
            .UseMauiCommunityToolkit()
			.ConfigureSyncfusionListView()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("Poppins-Regular.ttf", "Regular");
				fonts.AddFont("Poppins-SemiBold.ttf", "Semibold");
				fonts.AddFont("Poppins-Bold.ttf", "Bold");
				fonts.AddFont("Poppins-Medium.ttf", "Medium");
			});
		//Views
		builder.Services.AddSingleton<RegisterView>();
		builder.Services.AddSingleton<LoginView>();
        builder.Services.AddTransient<HomeView>();
        builder.Services.AddSingleton<StartView>();
        builder.Services.AddSingleton<ProfileView>();
        builder.Services.AddTransient<RegisterImageView>();
        builder.Services.AddSingleton<AddReviewView>();
        builder.Services.AddSingleton<SearchView>();
        builder.Services.AddTransient<SettingsView>();
        builder.Services.AddSingleton<PreferenceView>();
        builder.Services.AddSingleton<FavoritesView>();
        builder.Services.AddSingleton<VisitProfileView>();
        builder.Services.AddTransient<GameView>();
        builder.Services.AddTransient<TrendingView>();
        builder.Services.AddTransient<ReviewView>();

		//ViewModels
        builder.Services.AddSingleton<StartViewModel>();
        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddTransient<ProfileViewModel>();
        builder.Services.AddSingleton<AddReviewModel>();
        builder.Services.AddSingleton<SearchViewModel>();
        builder.Services.AddTransient<SettingsViewModel>();
        builder.Services.AddSingleton<PrefrencesViewModel>();
        builder.Services.AddSingleton<FavoritesViewModel>();
        builder.Services.AddSingleton<VisitProfileViewModel>();
        builder.Services.AddTransient<GameViewModel>();
        builder.Services.AddTransient<TrendingViewModel>();
        builder.Services.AddTransient<ReviewViewModel>();

		//Services
		builder.Services.AddSingleton<StartService>();
		builder.Services.AddSingleton<ProfileService>();
		builder.Services.AddSingleton<AddReviewService>();
		builder.Services.AddSingleton<SearchService>();
		builder.Services.AddSingleton<GameService>();
		builder.Services.AddSingleton<HomeService>();
		builder.Services.AddSingleton<TrendingService>();
		builder.Services.AddSingleton<FavoritesService>();
		builder.Services.AddSingleton<VisitUserProfileService>();
		builder.Services.AddSingleton<ReviewService>();
		builder.Services.AddTransient<SettingsService>();

        return builder.Build();
	}
}
