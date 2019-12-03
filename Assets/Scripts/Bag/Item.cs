using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Bag/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon;

    public virtual void Use()
    {
        Debug.Log($"Using {name}");
    }
}
