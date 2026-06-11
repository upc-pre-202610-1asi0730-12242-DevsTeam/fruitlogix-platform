namespace DevelopersTeam.Fruitlogix.Platform.Logistics.Domain.Model.Commands;

public record ReportDelayCommand(int DeliveryId, string Reason);