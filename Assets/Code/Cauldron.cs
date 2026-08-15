using System.Collections.Generic;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("Broadcast Events")]
    [SerializeField] ItemEventChannel onItemAddedToPotion;
    [SerializeField] ItemEventChannel onItemRemovedFromPotion;

    [Header("Public Properties")]
    public List<Item> itemsInPotion = new List<Item>();

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
            Item item = collision.GetComponent<Item>();

            itemsInPotion.Add(item);
            onItemAddedToPotion.RaiseEvent(item);
        }
    }

    public void Clean()
    {
        foreach (Item item in itemsInPotion)
        {
            onItemRemovedFromPotion.RaiseEvent(item);
        }

        itemsInPotion.Clear();
    }
}
