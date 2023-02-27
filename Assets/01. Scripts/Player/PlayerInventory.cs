using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] float itemDetectRadius = 5f;

    [SerializeField] List<ItemSlot> itemSlots = new List<ItemSlot>();

    private void Start()
    {
        for(int i = 0; i < 10; i ++)
            itemSlots.Add(new ItemSlot());
    }

    private void Update()
    {
        if(CheckNearItem(out List<Item> itemList))
        {
            foreach(Item item in itemList)
            {
                foreach(ItemSlot slot in itemSlots)
                {
                    if(slot.TrySetItem(item.ItemSO))
                    {
                        item.Collect(transform, slot);
                        break;
                    }
                }
            }
        }
    }

    private bool CheckNearItem(out List<Item> items)
    {
        items = new List<Item>();
        
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, itemDetectRadius, DEFINE.ItemLayer);

        if(detectedColliders.Length <= 0)
            return false;
        
        foreach(Collider col in detectedColliders)
            if(col.TryGetComponent<Item>(out Item item))
                items.Add(item);
        
        return true;
    }

    #if UNITY_EDITOR
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, itemDetectRadius);    
    }
    
    #endif
}
