using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxDoorOpen : MonoBehaviour
{
    public string OpenPositionName;

    public Vector3 OpenRotate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OpenPositionName == CameraManager.Instance.CurrentCameraPositionName)
            gameObject.transform.localRotation = Quaternion.Euler(OpenRotate);
        else gameObject.transform.localRotation = Quaternion.identity;
    }
}
