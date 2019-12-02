using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    #region Singleton
    public static Bag instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one bag instance");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();
    public int size = 9;

    public void Add (Item item)
    {
        if (Fits())
        {
            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
    }

    public void Remove (Item item)
    {
        items.Remove(item);
    }

    public bool Fits()
    {
        return size > items.Count;
    }
}
