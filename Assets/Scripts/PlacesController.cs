using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacesController : MonoBehaviour
{
    [SerializeField, Tooltip("Arreglo de gameobjets de los espacios 360")]
    private GameObject[] room;
    public void ChangeRoomTour()
    {
        room[0].SetActive(false);
        room[1].SetActive(true);
    }
    
    public void ChangeRoomTour0()
    {
        room[0].SetActive(true);
        room[1].SetActive(false);
    }
}
