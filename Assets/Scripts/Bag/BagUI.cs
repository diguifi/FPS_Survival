using UnityEngine;

public class BagUI : MonoBehaviour
{
    public Transform itemsParent;
    public BagSlot[] slots;
    public GameObject bagUI;
    Bag bag;

    // Start is called before the first frame update
    void Start()
    {
        bag = Bag.instance;
        bag.onItemChangedCallback += UpdateUI;

        slots = GetComponentsInChildren<BagSlot>();

        bagUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Bag"))
        {
            bagUI.SetActive(!bagUI.activeSelf);

            if(Cursor.lockState == CursorLockMode.None) {
                bagUI.SetActive(true);
            }
        }
    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length ; i++)
        {
            if (i < bag.items.Count)
            {
                slots[i].AddItem(bag.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
