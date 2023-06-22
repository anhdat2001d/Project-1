namespace Persistence;

public class Staff {
    public int StaffID { get; set; }
    public string StaffName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? Address { get; set; } = string.Empty;
    public int TitleID { get; set; }
}