using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField, Tooltip("Velocidad de rotación con ratón")]
    private float SpeedRotation = 5;
    [SerializeField, Tooltip("Velocidad de rotación automática")]
    private float SpeedRotationAuto = 6f;
    [SerializeField, Tooltip("Velocidad del zoom automático")]
    private float SpeedZoomAuto = 0.005f;

    [SerializeField, Tooltip("Slider para zoom")]
    private Slider SliderZoom;

    [SerializeField, Tooltip("Tiempo a esperar la inactividad")]
    private float waitTime;
    private Camera cam;
    private float idle_time = 0;
    private void Start()
    {
        cam = GetComponent<Camera>();
        StartCoroutine(WaitStart());
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && !IsMouseOverUI())
        {
            idle_time = 0;
            transform.eulerAngles -= SpeedRotation * new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        } else
        if (cam.fieldOfView <= 120 && Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            idle_time = 0;
            cam.fieldOfView = cam.fieldOfView + 5;
        } else
        if (cam.fieldOfView >= 7 && Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            idle_time = 0;
            cam.fieldOfView = cam.fieldOfView - 5;
        }
        else
        {
            idle_time += Time.deltaTime;
            if(idle_time >= waitTime)
            {
                var angles = transform.rotation.eulerAngles;
                angles.y += Time.deltaTime * SpeedRotationAuto;
                transform.rotation = Quaternion.Euler(angles);

                if (cam.fieldOfView>45)
                {
                    cam.fieldOfView = cam.fieldOfView - SpeedZoomAuto;
                }
            }
            print(idle_time);
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
    void MouseWheeling()
    {
        //float field_view = cam.fieldOfView;
        
    }

    IEnumerator WaitStart()
    {
        yield return new WaitForSeconds(2.7f);
        gameObject.GetComponent<Animator>().enabled = false;
    }
}
