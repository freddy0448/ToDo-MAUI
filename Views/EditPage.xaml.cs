using ToDo_MAUI.ViewModels;

namespace ToDo_MAUI.Views;

public partial class EditPage : ContentPage
{
	public EditPage(EditViewModel editViewModel)
	{
		InitializeComponent();
		BindingContext = editViewModel;
	}
}