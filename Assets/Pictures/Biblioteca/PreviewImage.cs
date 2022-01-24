using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewImage : MonoBehaviour
{
    [SerializeField] Material materialCube;
    [SerializeField] RawImage imageRaw;
    // Start is called before the first frame update
    void Start()
    {
        imageRaw.texture = materialCube.mainTexture;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
