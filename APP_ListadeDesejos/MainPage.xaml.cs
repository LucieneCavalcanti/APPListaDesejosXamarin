namespace APP_ListadeDesejos;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private void AcessarAPP(object sender, EventArgs e)
	{
		btnAcessar.Text = "Clicou";
		SemanticScreenReader.Announce(btnAcessar.Text);
	}
}

