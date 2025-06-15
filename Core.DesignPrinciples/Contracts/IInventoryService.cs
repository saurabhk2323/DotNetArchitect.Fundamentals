namespace Core.DesignPrinciples.Contracts
{
    public interface IInventoryService
    {
        void UpdateInventory(string? productId, int quantity);

        bool CheckProductAvailability(string? productId, int quantity);
    }
}
