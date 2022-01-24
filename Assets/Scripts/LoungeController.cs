using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoungeController : MonoBehaviour
{
    [SerializeField, Tooltip("Contenido del panel con galeria de lugares")]
    private Transform PanelContent;

    public void PlaceSelectedValidate(int except)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
            {
                //print(transform.name + ": " + transform.GetChild(i).gameObject.name + " disabled");
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        transform.GetChild(except).gameObject.SetActive(true);

        
        for (int j = 0; j < PanelContent.transform.childCount; j++)
        {
            if (PanelContent.transform.GetChild(j).gameObject.transform.GetChild(1).gameObject.activeSelf)
            {
                PanelContent.transform.GetChild(j).gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
        
        PanelContent.transform.GetChild(except).gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }
}
