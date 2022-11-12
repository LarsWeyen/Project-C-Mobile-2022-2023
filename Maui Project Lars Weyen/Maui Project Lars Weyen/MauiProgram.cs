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
        builder.Services.AddTransient<GameView>();

		//ViewModels
        builder.Services.AddSingleton<StartViewModel>();
        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddSingleton<ProfileViewModel>();
        builder.Services.AddSingleton<AddReviewModel>();
        builder.Services.AddSingleton<SearchViewModel>();
        builder.Services.AddTransient<GameViewModel>();

		//Services
		builder.Services.AddSingleton<LoginAndRegisterService>();
		builder.Services.AddSingleton<ProfileService>();
		builder.Services.AddSingleton<AddReviewService>();
		builder.Services.AddSingleton<SearchService>();
		builder.Services.AddSingleton<GameService>();
		
        return builder.Build();
	}
}
