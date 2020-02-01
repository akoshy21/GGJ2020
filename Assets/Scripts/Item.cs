using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum size { Small, Medium, Large }
    public size itemSize;

    public Item()
    {
    }

    public Item(size itemSz)
    {
        itemSize = itemSz;
    }
}
