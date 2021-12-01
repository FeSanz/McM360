using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject infoButton;
    [SerializeField] private GameObject infoText;
    [SerializeField] private Sprite infoSprite;
    [SerializeField] private Sprite closeSprite;

    private Button button;
    private Image image;
    private bool infoBool = true;

    void Start()
    {
        button = infoButton.GetComponent<Button>();
        image = infoButton.GetComponent<Image>();

        button.onClick.AddListener(filterAction);
        
    }

    public void filterAction() {

        if (infoBool)
        {
            showInfo();
        }

        else {
            HideInfo();
        }
    }


    private void showInfo() {
        infoBool = false;
        image.sprite = closeSprite;
        infoText.SetActive(true);
    }

    private void HideInfo() {
        infoBool = true;
        image.sprite = infoSprite;
        infoText.SetActive(false);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }


}
