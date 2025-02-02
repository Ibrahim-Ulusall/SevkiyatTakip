namespace Sevkiyat.Takip.Core.Models.Settings.Sessions;
public partial class SessionSettings
{
    public double IdleTimeout { get; set; }
    public string? CookieName { get; set; }
    public bool IsEssential { get; set; }
}
