using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeImage : MonoBehaviour
{
    int i = 0;
    [SerializeField] Material material;
    [SerializeField] Cubemap[] images;
    public void NextImage()
    {
        i++;
        material.SetTexture("_Tex", images[i]);
    }
    public void PreviusImage()
    {
        i--;
        material.SetTexture("_Tex", images[i]);
    }
}
