using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField, Tooltip("Velocidad de rotación con ratón")]
    private float SpeedRotation = 2.0f;
    [SerializeField, Tooltip("Velocidad de rotación automática")]
    private float SpeedRotationAuto = 6.0f;
    [SerializeField, Tooltip("Campo de visión de la camara por default")]
    private float FieldOfViewDefault = 60.0f;
    [SerializeField, Tooltip("Velocidad del zoom automático")]
    private float SpeedZoomAuto = 0.005f;
    [SerializeField, Tooltip("Valor máximo para alejarse con zoom")]
    private float ZoomMaximum = 70.0f;
    [SerializeField, Tooltip("Valor minímo para acercarse con zoom")]
    private float ZoomManimum = 30.0f;
    [SerializeField, Tooltip("Tiempo de espera para activar la autorotación")]
    private float waitTime;
    
    private Camera _camera;
    private float _idleTime = 0;
    
    private float _horizontal = 0f;
    private float _vertical = 0f;
    
    private void Start()
    {
        _camera = GetComponent<Camera>();
        StartCoroutine(WaitStart());
    }
    void Update()
    {
        //Valida y ejecuta rotacion y zoom con raton
        if (Input.GetMouseButton(0) && !IsMouseOverUI())
        {
            _idleTime = 0;
            _horizontal -= SpeedRotation * Input.GetAxis("Mouse Y");
            _vertical += SpeedRotation * Input.GetAxis("Mouse X");
            
            transform.eulerAngles = new Vector3(_horizontal, _vertical, 0f);
            
            //transform.eulerAngles -= SpeedRotation * new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
            //transform.eulerAngles += SpeedRotation * new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
            //transform.Rotate((Input.GetAxis("Mouse Y") * SpeedRotation * Time.deltaTime), (Input.GetAxis("Mouse X") * SpeedRotation * Time.deltaTime), 0);
        } 
        else if (_camera.fieldOfView < ZoomMaximum && Input.GetAxis("Mouse ScrollWheel") < 0 && !IsMouseOverUI())
        {
            _idleTime = 0;
            _camera.fieldOfView = _camera.fieldOfView + 5;
        } 
        else if (_camera.fieldOfView > ZoomManimum && Input.GetAxis("Mouse ScrollWheel") > 0 && !IsMouseOverUI())
        {
            _idleTime = 0;
            _camera.fieldOfView = _camera.fieldOfView - 5;
        }
        else
        {
            _idleTime += Time.deltaTime; //Inicia tiempo de inactividad
            if(_idleTime >= waitTime) //Valida tiempo de espera
            {
                //Inicia autorotacion
                var angles = transform.rotation.eulerAngles;
                angles.y += Time.deltaTime * SpeedRotationAuto;
                transform.rotation = Quaternion.Euler(angles);

                //Valida campo de vision de camara y resetea zoom para autorotacion
                if (_camera.fieldOfView < 44)
                {
                    _camera.fieldOfView = FieldOfViewDefault;
                }
                if (_camera.fieldOfView > 45)
                {
                    _camera.fieldOfView = _camera.fieldOfView - SpeedZoomAuto;
                }
            }
        }
    }

    /// <summary>
    /// Verifica si el cursor no se encuentra encima de un elemento de la UI para evitar rotar
    /// </summary>
    /// <returns>True si esta encima de un elemento de la UI y viceversa</returns>
    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    /// <summary>
    /// Método para rotar a la izquiera con botones en menú
    /// </summary>
    public void LeftCamera()
    {
        transform.eulerAngles += new Vector3(0,(-SpeedRotation * Time.deltaTime) * 100,0);
    }
    
    /// <summary>
    /// Método para rotar a la derecha con botones en menú
    /// </summary>
    public void RigthCamera()
    {
        transform.eulerAngles += new Vector3(0,(SpeedRotation * Time.deltaTime) * 100,0);
    }
    
    /// <summary>
    /// Método para rotar hacia arriba con botones en menú
    /// </summary>
    public void UpCamera()
    {
        transform.eulerAngles += new Vector3((-SpeedRotation * Time.deltaTime) * 100,0,0);
    }
    
    /// <summary>
    /// Método para rotar hacia abajo con botones en menú
    /// </summary>
    public void DownCamera()
    {
        transform.eulerAngles += new Vector3((SpeedRotation * Time.deltaTime) * 100,0, 0);
    }
    
    /// <summary>
    /// Aumentar zoom con botones en menú
    /// </summary>
    public void moreZoom()
    {
        if (_camera.fieldOfView > ZoomManimum)
        {
            _camera.fieldOfView = _camera.fieldOfView - 5;
        }
    }
    /// <summary>
    /// Disminuir zoom con botones en menú
    /// </summary>
    public void lessZoom()
    {
        if (_camera.fieldOfView < ZoomMaximum)
        {
            _camera.fieldOfView = _camera.fieldOfView + 5;
        }
    }
    
    /// <summary>
    /// Detener autorotación
    /// </summary>
    public void StopRotationAndMovement()
    {
        _idleTime = 0;
    }
    
    /// <summary>
    /// Reinicio de rotacion y zoom de camara
    /// </summary>
    public void ResetCameraProperties()
    {
        _idleTime = 0;
        _camera.fieldOfView = FieldOfViewDefault;
        transform.eulerAngles = new Vector3(0,0,0);
    }
    
    /// <summary>
    /// Desactivar animacion inicial de cámara
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitStart()
    {
        yield return new WaitForSeconds(2.7f);
        gameObject.GetComponent<Animator>().enabled = false;
    }
}
