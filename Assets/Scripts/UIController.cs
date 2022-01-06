using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
  [SerializeField, Tooltip("Animacion para mostrar galeria de habitaciones en menu")]
  private Animator MenuRoomsAnimator;

  [SerializeField, Tooltip("Canvas Group de Panel Rooms")]
  private CanvasGroup PanelRooms;

  [SerializeField, Tooltip("Arreglo gameobjets de salas")]
  private GameObject[] Salas;

  public void ShowHideMenuRooms()
  {
    if (PanelRooms.alpha > 0.9f)
    {
      MenuRoomsAnimator.Play("HideGaleryMenu");
    }
    else
    {
      MenuRoomsAnimator.Play("ShowGaleryMenu");
    }
  }

  public void ShowHideSalas(int except)
  {
    foreach (GameObject Sala in Salas)
    {
      Sala.SetActive(false);
    }
    
    Salas[except].SetActive(true);
  }
}
