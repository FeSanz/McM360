using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationPanelController : MonoBehaviour
{
  [SerializeField, Tooltip("Animacion para cerrar app")]
  private Animator CloseAppAnimator;
  [SerializeField, Tooltip("Animacion para mostrar menu")]
  private Animator MenuRoomsAnimator;

  [SerializeField, Tooltip("Canvas Group de Panel Rooms")]
  private CanvasGroup PanelRooms;
  public void ShowCloseAppPanel()
  {
    CloseAppAnimator.Play("Fade-in");
  }
  
  public void AcceptCloseApp()
  {
#if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;
#else
       Application.Quit(); 
#endif

  }
  
  public void DeclineCloseApp()
  {
    CloseAppAnimator.Play("Fade-out");
  }

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

}
