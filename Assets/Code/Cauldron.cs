using System.Collections.Generic;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("Broadcast Events")]
    [SerializeField] ItemEventChannel onItemAddedToPotion;
    [SerializeField] ItemEventChannel onItemRemovedFromPotion;

    [Header("Public Properties")]
    public List<GrabbableItem> itemsInPotion = new List<GrabbableItem>();

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            GrabbableItem item = collision.GetComponent<GrabbableItem>();

            itemsInPotion.Add(item);
            onItemAddedToPotion.RaiseEvent(item);
        }
    }

    public void Clean()
    {
        foreach (GrabbableItem item in itemsInPotion)
        {
            onItemRemovedFromPotion.RaiseEvent(item);
        }

        itemsInPotion.Clear();
    }
}
