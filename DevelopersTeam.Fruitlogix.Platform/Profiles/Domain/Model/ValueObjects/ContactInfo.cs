namespace DevelopersTeam.Fruitlogix.Platform.Profiles.Domain.Model.ValueObjects;

public record ContactInfo
{
    public string Email { get; }
    public string Phone { get; }

    public ContactInfo(string email, string phone)
    {
        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            throw new ArgumentException("Invalid email address.");
        if (string.IsNullOrWhiteSpace(phone) || phone.Length < 6)
            throw new ArgumentException("Invalid phone number.");
        Email = email;
        Phone = phone;
    }
}