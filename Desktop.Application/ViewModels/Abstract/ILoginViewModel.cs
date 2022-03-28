namespace Desktop.Presentation.ViewModels.Abstract;

internal interface ILoginViewModel
{
    public string Password { get; set; }
    public SecureString SecurePassword { get; set; }

    public string RegisterPassword { get; set; }
    public SecureString SecureRegisterPassword { get; set; }
}