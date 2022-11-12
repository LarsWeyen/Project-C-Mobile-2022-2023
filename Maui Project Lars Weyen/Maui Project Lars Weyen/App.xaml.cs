using Maui_Project_Lars_Weyen.Models;
using Maui_Project_Lars_Weyen.Views;

namespace Maui_Project_Lars_Weyen;

public partial class App : Application
{
	public static User userInfo;
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
	}
}
