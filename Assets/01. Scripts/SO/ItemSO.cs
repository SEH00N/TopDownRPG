using UnityEngine;

[CreateAssetMenu(menuName = "SO/Item")]
public class ItemSO : ScriptableObject
{
    [SerializeField] string itemName = "";
    public string ItemName => itemName;

    [SerializeField] int stackableCount = 99;
    public int StackableCount => stackableCount;

    [SerializeField] Sprite itemImage = null;
    public Sprite ItemImage => itemImage;
}
