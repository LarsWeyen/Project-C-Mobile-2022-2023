using Maui_Project_Lars_Weyen.Models;
using Maui_Project_Lars_Weyen.Views;

namespace Maui_Project_Lars_Weyen;

public partial class App : Application
{
	public static User userInfo;
	public static bool darkmode;
	public static string orderBy;
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
		Routing.RegisterRoute(nameof(RegisterView), typeof(RegisterView));
		Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
		Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
		Routing.RegisterRoute(nameof(RegisterImageView), typeof(RegisterImageView));
		Routing.RegisterRoute(nameof(ProfileView), typeof(ProfileView));
		Routing.RegisterRoute(nameof(AddReviewView), typeof(AddReviewView));
		Routing.RegisterRoute(nameof(GameView), typeof(GameView));
		Routing.RegisterRoute(nameof(TrendingView), typeof(TrendingView));
		Routing.RegisterRoute(nameof(SettingsView), typeof(SettingsView));
		Routing.RegisterRoute(nameof(PreferenceView), typeof(PreferenceView));
		Routing.RegisterRoute(nameof(FavoritesView), typeof(FavoritesView));
		Routing.RegisterRoute(nameof(VisitProfileView), typeof(VisitProfileView));
	}
}
