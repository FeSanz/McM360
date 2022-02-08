using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UIElements.Image;

public class UIController : MonoBehaviour
{
  [SerializeField, Tooltip("Arreglo gameobjets de salas")]
  private GameObject[] Salas;
  
  [SerializeField, Tooltip("Arreglo galerias de salas")]
  private GameObject[] ContentGaleries;

  [SerializeField, Tooltip("Etiqueta para el botón de galería")]
  private TextMeshProUGUI tagGalleryButton;

  private int _currentLounge = 0;
  public void ShowHideMenuRooms()
  {
    if (ContentGaleries[_currentLounge].GetComponent<CanvasGroup>().alpha > 0.9f)
    {
      ContentGaleries[_currentLounge].GetComponent<Animator>().Play("HideGaleryMenu");
      ContentGaleries[_currentLounge].GetComponent<Graphic>().raycastTarget = false;
      ContentGaleries[_currentLounge].gameObject.transform.GetChild(1).gameObject.SetActive(false);
      tagGalleryButton.SetText("Presione para ver galería");
    }
    else
    {
      ContentGaleries[_currentLounge].GetComponent<Animator>().Play("ShowGaleryMenu");
      ContentGaleries[_currentLounge].GetComponent<Graphic>().raycastTarget = true;
      ContentGaleries[_currentLounge].gameObject.transform.GetChild(1).gameObject.SetActive(true);
      tagGalleryButton.SetText("Presione para ocultar galería");
    }
  }

  public void ScrollActive()
  {
    ContentGaleries[_currentLounge].SetActive(true);
  }
  
  public void ScrollDesactive()
  {
    ContentGaleries[_currentLounge].SetActive(false);
  }

  public void ShowHideSalas(int except)
  {
    _currentLounge = except;
    for (int i = 0; i < Salas.Length; i++)
    {
      if (Salas[i].activeSelf && ContentGaleries[i].activeSelf)
      {
        Salas[i].SetActive(false);
        ContentGaleries[i].SetActive(false);
      }
    }
    ContentGaleries[except].SetActive(true);
    Salas[except].SetActive(true);
  }
  
}
