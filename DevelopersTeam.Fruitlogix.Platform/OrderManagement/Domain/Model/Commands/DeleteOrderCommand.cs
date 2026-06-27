namespace DevelopersTeam.Fruitlogix.Platform.OrderManagement.Domain.Model.Commands;

/// <summary>
///     Command to physically delete an order from the database.
/// </summary>
/// <remarks>
///     Author: TuCodigoDeAlumno
/// </remarks>
public record DeleteOrderCommand(int OrderId);