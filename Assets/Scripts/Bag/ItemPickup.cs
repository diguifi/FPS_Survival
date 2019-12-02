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
    }

    public void Pickup()
    {
        if (Bag.instance.Fits())
        {
            Debug.Log($"Picked up {item.name}");
            Bag.instance.Add(item);
            Destroy(gameObject);
        }
    }
}
