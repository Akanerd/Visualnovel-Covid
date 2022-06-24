using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    private float RotationSpeed = 5;
    public bool isDragging = false;

    public void setRotationSpeed(float newRtSpeed)
    {
        RotationSpeed = newRtSpeed;
    }
    private void OnMouseDown()
    {
        isDragging = true;
    }
    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void OnMouseDrag()
    {
        transform.Rotate((Input.GetAxis("Mouse Y") * RotationSpeed), 0, 0, Space.World);
    }
}
