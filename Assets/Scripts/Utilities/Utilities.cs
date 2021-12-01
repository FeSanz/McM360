using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    [SerializeField]
    private GameObject AlertDialogCloseAplication;
    /// <summary>
    /// Metodo para ver alerta para Toast para android.
    /// </summary>
    /// <param name="message">Mensage de tipo string para ver en el Toast.</param>
    public static void AndroidToastMessage(string message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity =
            unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject =
                    toastClass.CallStatic<AndroidJavaObject>(
                        "makeText", unityActivity, message, 0);
                toastObject.Call("show");
            }));
        }
    }

    /// <summary>
    /// Metodo para ver alerta de Debug en el Canvas
    /// </summary>
    /// <param name="message">Mensaje string para ver en la alerta</param>
    public void DebugText(string message, Colour color)
    {
        TextMeshProUGUI deb = GameObject.FindWithTag("Debug").GetComponent<TextMeshProUGUI>();
        Color customColor = new Color();

        if (color == Colour.Error)
        {
            customColor = Color.red;
        }
        if (color == Colour.Success)
        {
            customColor = Color.green;
        }
        if (color == Colour.Normal)
        {
            customColor = Color.white;
        }

        deb.color = customColor;
        deb.text = message;
    }
    public void CloseAplicationListener()
    {
        //Directiva para el Editor de Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    /// <summary>
    /// Método OnClick() para cancelar y ocultar la ventana de alerta para cerrar la aplicación
    /// </summary>
    public void CancelCloseAplicationListener()
    {
        AlertDialogCloseAplication.SetActive(false);
    }

    /// <summary>
    /// Método OnClick() para mostrar la alerta para cerrar la aplicación
    /// </summary>
    public void ShowAlertDialogCloseAplicationListener()
    {
        AlertDialogCloseAplication.SetActive(true);
    }

    /*
    /// <summary>
    /// Actually quit the application.
    /// </summary>
    private void DoQuit()
    {
        print("Se sale de la aplicacion");
        Application.Quit();
    }
    */
}

public enum Colour
{
    Error,
    Success,
    Normal
}

