namespace Persistence;

public class Phone {
    public int PhoneID { get; set; }
    public string PhoneName { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string? CPU { get; set; }
    // public Category CategoryID { get; set; }
    public string? RAM { get; set; }
    public decimal Price { get; set; }
    public string? BatteryCapacity { get; set; }
    public string OS { get; set; } = string.Empty;
    public string? SimSlot { get; set; }
    public string? ScreenHz { get; set; }
    public string? ScreenResolution { get; set; }
    public string? ROM { get; set; }
    public string? MobileNetwork { get; set; }
    public string? PhoneSize { get; set; }
}