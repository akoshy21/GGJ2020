using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum size { Small, Medium, Large }
    public size itemSize;
    public ItemSlot slot;

    public Quaternion origRotation;

    public Item()
    {
    }

    public Item(size itemSz)
    {
        itemSize = itemSz;
    }

    void Awake()
    {
        origRotation = this.transform.rotation;
    }

    public bool Fits(ItemSlot slot)
    {
        switch (slot.slotSize)
        {
            case size.Large:
                return true;
            case size.Medium:
                if (itemSize != size.Large)
                {
                    return true;
                }

                return false;
            case size.Small:
                if (itemSize == size.Small)
                {
                    return true;
                }

                return false;
            default:
                return false;
        }
    }

    public void Unslot()
    {
        if (slot != null)
        {
            slot.Unslot();
        }
    }
}
