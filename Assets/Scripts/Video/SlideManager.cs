using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//Este script debe tenerlo el componente al que se desea verifcar si se le ha hecho clic

public class SlideManager : MonoBehaviour//, IPointerDownHandler, IPointerUpHandler
{
    /*
    private TogglePlayPause togglePlayPause;

    public void Start()
    {
        togglePlayPause = GameObject.Find("Video Player").GetComponent<TogglePlayPause>();
    }
    //Cuando se hace click en el objeto
    public void OnPointerDown(PointerEventData eventData)
    {
        togglePlayPause.click = true;
        print("OnPointerDown click true no se hace el update");
    }

    //Cuando se libera el click
    public void OnPointerUp(PointerEventData eventData)
    {
        //Se obtiene el frame correspondiente a la posicion del slider
        togglePlayPause.slideValue = gameObject.GetComponent<Slider>().value;
        print("OnPointerUp antes del UpdateFrame = " + gameObject.GetComponent<Slider>().value);
        togglePlayPause.UpdateFrame();
        print("OnPointerUp despues del UpdateFrame click false = " + gameObject.GetComponent<Slider>().value);
        togglePlayPause.click = false;
    }
    */
}
