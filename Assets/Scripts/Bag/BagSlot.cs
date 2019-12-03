using UnityEngine;
using UnityEngine.UI;

public class BagSlot : MonoBehaviour
{
    public Button removeButton;
    public Image icon;
    Item item;

    public void AddItem(Item itemAdded)
    {
        item = itemAdded;

        icon.sprite = item.icon;
        icon.enabled = true;

        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;

        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Bag.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
