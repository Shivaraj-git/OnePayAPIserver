namespace OnePayAPI.Models.DTOs
{
    public record SignUpDTO(
        string FullName,
        string BusinessName,
        string? Email,
        string PhoneNumber,
        string Password
    );
}
