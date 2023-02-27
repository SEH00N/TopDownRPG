using UnityEngine;

[System.Serializable]
public class ItemSlot
{
    [SerializeField] private ItemSO currentItemData = null;
    [SerializeField] private int currentStackCount = 0;

    public bool TrySetItem(ItemSO itemData)
    {
        bool returnValue = false;

        if(currentItemData == null) //현재 아이템이 비어있는지 확인
            returnValue = true; //현재 아이템이 비어있으면 바로 아이템 넣기
        else if(currentItemData.ItemName == itemData.ItemName) //아이템이 무언가 들어있으면 서로 같은 아이템인지 확인
            if(currentItemData.StackableCount > currentStackCount) //서로 같은 아이템이면 스택이 가능한지 확인
                returnValue = true; //스택이 가능하면 쌓기

        //모든 조건문을 통과한 후 반환값이 false 라면 아이템 추가가 불가능한 상태
        //true라면 아이템 추가가 가능한 상태

        return returnValue;
    }    

    public void SetItem(ItemSO itemData)
    {
        currentItemData = itemData;

        currentStackCount++;
    }
}
