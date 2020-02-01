using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public GameObject grabbedObj;
    public GameObject holdPos;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                if (hit.collider.GetComponent<Item>() != null)
                {
                    if (grabbedObj == null)
                    {
                        grabbedObj = hit.collider.gameObject;
                        grabbedObj.transform.parent = holdPos.transform;
                    }
                    else
                    {
                        grabbedObj.transform.parent = null;
                        grabbedObj = hit.collider.gameObject;
                    }
                }
            }
            else {
                grabbedObj.transform.parent = null;
                grabbedObj = null;
            }
        }
    }
}
