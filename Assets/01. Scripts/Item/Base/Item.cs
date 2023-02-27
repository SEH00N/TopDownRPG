using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] ItemSO itemSO = null;
    public ItemSO  ItemSO => itemSO;

    [SerializeField] float collectingDuration = 1f;

    private Collider col = null;

    private void Awake()
    {
        col = GetComponent<Collider>();
    }

    public void Collect(Transform target, ItemSlot slot)
    {
        col.enabled = false;

        StartCoroutine(CollectCoroutine(target, slot));
    }

    private IEnumerator CollectCoroutine(Transform target, ItemSlot slot)
    {
        Vector3 startPos = transform.position;
        float timer = 0f;

        while(timer < collectingDuration) {
            transform.position = Vector3.Lerp(startPos, target.position, timer / collectingDuration);
            timer += Time.deltaTime;
                        
            yield return new WaitForEndOfFrame();
        }

        slot.SetItem(itemSO);
        gameObject.SetActive(false);
    }
}
