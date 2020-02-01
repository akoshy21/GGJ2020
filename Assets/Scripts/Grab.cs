using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEditorInternal;
using UnityEngine;
using UnityEngineInternal;

public class Grab : MonoBehaviour
{
    public GameObject grabbedObj;
    public GameObject hand;
    public Transform holdPos;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Transform objectHit = hit.transform;
                if (!hit.collider.CompareTag("surface"))
                {
                    if (hit.collider.GetComponent<Item>() != null)
                    {
                        if (grabbedObj == null)
                        {
                            Debug.Log("null");
                            grabbedObj = hit.collider.gameObject;
                            grabbedObj.GetComponent<Item>().Unslot();
                            grabbedObj.GetComponent<Rigidbody>().isKinematic = true;
                            grabbedObj.transform.position = holdPos.position;
                            grabbedObj.transform.parent = hand.transform;
                        }
                        else
                        {
                            Debug.Log("reset");
                            grabbedObj.transform.parent = null;
                            grabbedObj.GetComponent<Rigidbody>().isKinematic = false;
                            grabbedObj = hit.collider.gameObject;
                            grabbedObj.GetComponent<Item>().Unslot();
                            grabbedObj.GetComponent<Rigidbody>().isKinematic = true;
                        }
                    }
                    else if (hit.collider.GetComponent<ItemSlot>() != null)
                    {
                        Debug.Log("SLOT");
                        if (grabbedObj.GetComponent<Item>().Fits(hit.collider.GetComponent<ItemSlot>()))
                        {
                            hit.collider.GetComponent<ItemSlot>().Slot(grabbedObj);
                            grabbedObj = null;
                        }
                        else
                        {
                            //play doesnt fit sound
                        }
                    }
                    else
                    {
                        if (grabbedObj != null)
                        {
                            Debug.Log(hit.collider.name);
                            grabbedObj.transform.parent = null;
                            grabbedObj.GetComponent<Rigidbody>().isKinematic = false;
                            grabbedObj = null;
                        }
                    }
                }
            }
        }
    }
}
