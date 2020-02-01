using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public Item.size slotSize;
    public GameObject slottedItem;

    public void Slot(GameObject item)
    {
        item.transform.parent = null;
        item.transform.parent = this.transform;
        item.transform.position = this.transform.position;
        if (this.GetComponent<HingeJoint>() != null)
        {
            GetComponent<HingeJoint>().connectedBody = item.GetComponent<Rigidbody>();
        }

        item.GetComponent<Rigidbody>().isKinematic = false;

        slottedItem = item;
        slottedItem.GetComponent<Item>().slot = this;
    }

    public void Unslot()
    {
        slottedItem.GetComponent<Item>().slot = null;
        GetComponent<HingeJoint>().connectedBody = null;
        slottedItem.transform.parent = null;
        slottedItem = null;
    }
}
