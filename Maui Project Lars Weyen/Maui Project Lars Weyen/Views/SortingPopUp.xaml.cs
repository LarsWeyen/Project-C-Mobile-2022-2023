using AndroidX.Lifecycle;
using CommunityToolkit.Maui.Views;
using Maui_Project_Lars_Weyen.Models;
using Maui_Project_Lars_Weyen.ViewModels;
using static Android.App.Assist.AssistStructure;

namespace Maui_Project_Lars_Weyen.Views;

public partial class SortingPopUp : Popup
{
	public SortingPopUp()
	{
		InitializeComponent();
    }  

	private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		if (rbRecent.IsChecked)
		{
			Sorting obj = new Sorting() { OrderBy = "ReviewId", SortBy = "desc" };
            this.Close(obj);
		}
		else if (rbRatingH.IsChecked)
		{
            Sorting obj = new Sorting() { OrderBy = "Rating", SortBy = "desc" };        
            this.Close(obj);
        }
		else
		{
            Sorting obj = new Sorting() { OrderBy = "Rating", SortBy = "asc" };  
            this.Close(obj);
        }
	}
}