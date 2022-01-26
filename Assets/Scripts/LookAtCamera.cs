using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    void LateUpdate()
    {
        transform.LookAt(Camera.main.transform, Vector3.down);
        //transform.rotation = Camera.main.transform.rotation;
    }
}
