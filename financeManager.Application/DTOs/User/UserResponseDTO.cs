namespace financeManager.Application.DTOs.User;

public record UserResponseDTO(
    int Id,
    string Name,
    string Email,
    DateTime CreatedAt,
    DateTime UpdatedAt
);