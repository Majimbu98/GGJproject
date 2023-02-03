[System.Serializable]
public class InventoryEntry
{
    public ItemSO Item;
    public int Quantity;

    public InventoryEntry(ItemSO item)
    {
        Item = item;
        Quantity = 1;
    }
}

