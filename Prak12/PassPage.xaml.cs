using System.Text;

namespace Prak12;

public partial class PassPage : ContentPage
{
    private StringBuilder codeBuilder = new StringBuilder();

    public PassPage()
    {
        InitializeComponent();
    }

    private void OnNumberButtonClicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            if (codeBuilder.Length < 4)
            {
                codeBuilder.Append(button.Text);
                UpdatePasswordLabel();
            }
        }
    }

    private void OnClearButtonClicked(object sender, EventArgs e)
    {
        codeBuilder.Clear();
        UpdatePasswordLabel();
    }

   
    private void UpdatePasswordLabel()
    {
        PasswordLabel.Text = new string('*', codeBuilder.Length);
    }
}