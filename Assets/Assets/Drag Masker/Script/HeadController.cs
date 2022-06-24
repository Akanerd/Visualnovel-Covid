using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{
    private Vector3 slide;
    public float slidePower = 5;
    void Start()
    {
        
    }

    void Update()
    {
        slide = new Vector3(Input.GetAxis("Mouse X"),0,0);
    }
    private void OnMouseDrag()
    {
        transform.position += slide*slidePower*Time.deltaTime;
    }
}
