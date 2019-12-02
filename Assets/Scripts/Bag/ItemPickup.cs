using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();
        Pickup();
        Destroy(gameObject);
    }

    public void Pickup()
    {
        Debug.Log($"Picked up {item.name}");
    }
}
