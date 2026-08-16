using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    [Header("Broadcast Events")]
    [SerializeField] ItemEventChannel onItemAddedToPotion;
    [SerializeField] ItemEventChannel onItemRemovedFromPotion;

    [Header("Public Properties")]
    public List<Item> itemsInPotion = new List<Item>();

    private Color _defaultColor;

    private void Start()
    {
        _defaultColor = spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Item item = collision.GetComponent<Item>();

            itemsInPotion.Add(item);
            onItemAddedToPotion.RaiseEvent(item);

            spriteRenderer.color = Random.ColorHSV(0, 1, 0.3f, 1, 0.5f, 1, 1, 1);
        }
    }

    public Statistics GetPotion()
    {
        Statistics potion = new Statistics();

        foreach (Item item in itemsInPotion)
        {
            potion += item.stats;
        }

        return potion;
    }

    public void Refill()
    {
        animator.SetTrigger("ShouldRefill");
    }

    public void Clear()
    {
        foreach (Item item in itemsInPotion)
        {
            onItemRemovedFromPotion.RaiseEvent(item);
        }
        spriteRenderer.color = _defaultColor;
        itemsInPotion.Clear();
    }
}
