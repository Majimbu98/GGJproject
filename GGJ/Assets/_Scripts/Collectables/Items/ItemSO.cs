using UnityEngine;

[CreateAssetMenu(fileName = "Item_", menuName = "Collectables/New Item", order = 0)]
public class ItemSO : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
}