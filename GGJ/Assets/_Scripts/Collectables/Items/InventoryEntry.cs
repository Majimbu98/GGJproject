[System.Serializable]
public class InventoryEntry
{
    public ItemSO Item;
    public int Quantity;

    public Collectable owner { get; private set; }
    
    public InventoryEntry(ItemSO item, Collectable _owner)
    {
        Item = item;
        Quantity = 1;
        owner = _owner;
    }
    
    public InventoryEntry(ItemSO item)
    {
        Item = item;
        Quantity = 1;
    }
}

