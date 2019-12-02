using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Bag/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon;
}
