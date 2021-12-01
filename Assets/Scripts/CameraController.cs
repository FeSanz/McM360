using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField, Tooltip("Velocidad de rotación con ratón")]
    private float SpeedRotation = 5;

    [SerializeField, Tooltip("Slider para zoom")]
    private Slider SliderZoom;
    
    void Update()
    {
        if(Input.GetMouseButton(0) && !IsMouseOverUI())
        {
            transform.eulerAngles += SpeedRotation * new Vector3( -Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"),0) ;
        }
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    public void LeftCamera()
    {
        transform.eulerAngles += new Vector3(0,(-SpeedRotation * Time.deltaTime) * 100,0);
    }
    
    public void RigthCamera()
    {
        transform.eulerAngles += new Vector3(0,(SpeedRotation * Time.deltaTime) * 100,0);
    }
    
    public void UpCamera()
    {
        transform.eulerAngles += new Vector3((-SpeedRotation * Time.deltaTime) * 100,0,0);
    }
    
    public void DownCamera()
    {
        transform.eulerAngles += new Vector3((SpeedRotation * Time.deltaTime) * 100,0, 0);
    }
    
    public void Zoom()
    {
        print("Slider:" + SliderZoom.value);
        transform.position = new Vector3(0,0, (SliderZoom.value * Time.deltaTime) * 100);
    }
}
