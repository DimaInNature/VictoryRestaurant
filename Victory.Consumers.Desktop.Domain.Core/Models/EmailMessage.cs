namespace Victory.Consumers.Desktop.Domain.Core.Models;

public class EmailMessage
{
    public string Subject { get; set; } = string.Empty;

    public string Text { get; set; } = string.Empty;

    public EmailMessage(string subject, string text) => (Subject, Text) = (subject, text);

    public EmailMessage() { }
}