using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private CanvasGroup CanvasVideo;
    [SerializeField] private Image progress;
    private bool isPlaying = false;
    public Button buttonPlay;
    public Button buttonPause;
    public Text min;
    public Text sec;
    public Text minTot;
    public Text secTot;
    //public Slider slider;
    //public bool click = false;
    //public float slideValue = 0;


    private void Awake()
    {
        string minutes = Mathf.Floor((int)videoPlayer.clip.length / 60).ToString("00");
        string seconds = ((int)videoPlayer.clip.length % 60).ToString("00");
        minTot.text = minutes;
        secTot.text = seconds;
    }

    public void SetCurrentTime()
    {
        print("SetCurrentTime time: " + videoPlayer.time.ToString());
        print("SetCurrentTime frame: " + videoPlayer.frame.ToString());
        string minutes = Mathf.Floor((int)videoPlayer.time / 60).ToString("00");
        string seconds = ((int)videoPlayer.time % 60).ToString("00");
        min.text = minutes;
        sec.text = seconds;
    }

    public void ToggleButton()
    {
        if (isPlaying)
        {
            videoPlayer.Pause();
            buttonPlay.gameObject.SetActive(true);
            buttonPause.gameObject.SetActive(false);
            isPlaying = false;
        }
        else
        {
            videoPlayer.Play();
            buttonPlay.gameObject.SetActive(false);
            buttonPause.gameObject.SetActive(true);
            isPlaying = true;
        }
    }

    public void Stop()
    {
        videoPlayer.Stop();

        buttonPlay.gameObject.SetActive(true);
        buttonPause.gameObject.SetActive(false);
        //slider.value = 0;
        isPlaying = false;
    }

    //public IEnumerator UpdateFrame()
    /*
    public void UpdateFrame()
    {
        print("UpdateFrame = " + slider.value);
        float frame = slideValue * (float)videoPlayer.frameCount;
        videoPlayer.frame = (long)frame;
        //slider.value = slideValue;
        //yield return new WaitForSeconds(2f);
    }
    */

    private void Update()
    {
        if (CanvasVideo.alpha == 0f)
        {
            videoPlayer.Pause();
            buttonPlay.gameObject.SetActive(true);
            buttonPause.gameObject.SetActive(false);
            isPlaying = false;
        }
        //Si esta en modo reproduccion, y no ha llegado al final del video sigue adelantando la barra
        /*&& videoPlayer.frameCount > 0*/ //Nunca le voy a meter un video vacío :P
        if (isPlaying && (float)videoPlayer.frame < (float)videoPlayer.frameCount)
        {
            //print("Update time: " + videoPlayer.time.ToString());
            //rint("Update frame: " + videoPlayer.frame.ToString());
            SetCurrentTime();
            //tiempo.text = videoPlayer.time.ToString() + " / " + duration.ToString();
            progress.fillAmount = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
        }
        //SI el video ya llegó al final
        if((float)videoPlayer.frame == (float)videoPlayer.frameCount-1)
        {
            videoPlayer.Stop();
            progress.fillAmount = 0;
            min.text = "00";
            sec.text = "00";
            buttonPlay.gameObject.SetActive(true);
            buttonPause.gameObject.SetActive(false);
            isPlaying = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        TrySkip(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TrySkip(eventData);
    }

    private void TrySkip(PointerEventData eventData)
    {
        //TErcer parametro es null porque es la pantalla del dispositivo, si fuera World space sería la cámara
        Vector2 localPoint;
        // Si el click esta dentro del objeto "progress" nos devuelve la posicion donde fué el click
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            progress.rectTransform, eventData.position, null, out localPoint))
        {
            //Nos da el porcentaje equivalente a donde se hizo el click en la barra
            float pct = Mathf.InverseLerp(progress.rectTransform.rect.xMin, progress.rectTransform.rect.xMax, localPoint.x);
            SkipToPercent(pct);
        }
    }

    private void SkipToPercent(float pct)
    {
        //print("SkipToPercent time: " + videoPlayer.time.ToString());
        //print("SkipToPercent frame: " + videoPlayer.frame.ToString());
        var frame = videoPlayer.frameCount * pct;
        //print("--------------------------------------------------");
        //print("frame calculado" + frame);
        //print("--------------------------------------------------");
        videoPlayer.frame = (long)frame;    //este valor lo toma hasta el otro frame
        //Mueve la barra de estado sin importar si está puasado o reproduciendo
        progress.fillAmount = pct;
        // regla de 3 para sacar el tiempo a travez del frame
        var numerador = (frame * videoPlayer.clip.length);
        var resultado = numerador / videoPlayer.frameCount;
        /*print("--------------------------------------------------");
        print("tiempo calculado: " + resultado);
        print("--------------------------------------------------");
        print(Mathf.Floor((int)resultado / 60).ToString("00"));
        print(((int)resultado % 60).ToString("00"));
        print("SkipToPercent time2: " + videoPlayer.time.ToString());
        print("SkipToPercent frame: " + videoPlayer.frame.ToString());*/
        SetCurrentTime();
    }
}