using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private bool inventoryEnabled;
    public GameObject inventory;
    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;
    public GameObject slotHolder;

    void Start()
    {
        allSlots = slotHolder.transform.childCount;
        slot = new GameObject[allSlots];
        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<SlotManager>().item == null)
            {
                slot[i].GetComponent<SlotManager>().empty = true;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }

        if (inventoryEnabled)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Item")
        {
            GameObject itemPickedUp = other.gameObject;
            ItemManager item = itemPickedUp.GetComponent<ItemManager>();
            AddItem(itemPickedUp, item.ID, item.type, item.description, item.icon);
        }
    }

    public void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<SlotManager>().empty)
            {
                itemObject.GetComponent<ItemManager>().pickedUp = true;
                slot[i].GetComponent<SlotManager>().item = itemObject;
                slot[i].GetComponent<SlotManager>().ID = itemID;
                slot[i].GetComponent<SlotManager>().type = itemType;
                slot[i].GetComponent<SlotManager>().description = itemDescription;
                slot[i].GetComponent<SlotManager>().icon = itemIcon;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);

                slot[i].GetComponent<SlotManager>().UpdateSlot();

                slot[i].GetComponent<SlotManager>().empty = false;

                return;
            }
        }
    }
}
