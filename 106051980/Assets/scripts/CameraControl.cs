using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;

    [Tooltip("距離仰角"), Range(0.5f, 10f)]
    public float distanceUp = 10f;
    [Tooltip("距離遠近"), Range(0.5f, 10f)]
    public float distanceAway = 5f;
    [Tooltip("位置平滑移動值"), Range(0.5f, 5f)]
    public float smooth = 2f;
    [Tooltip("位置景深")]
    public float camDepthSmooth = 5f;

    // Use this for initialization


   
    // Update is called once per frame
    void Update()
    {
        
        if ((Input.mouseScrollDelta.y < 0 && Camera.main.fieldOfView >= 3) || Input.mouseScrollDelta.y > 0 && Camera.main.fieldOfView <= 80)
        {
            Camera.main.fieldOfView += Input.mouseScrollDelta.y * camDepthSmooth * Time.deltaTime;
        }

    }

    void LateUpdate()
    {
        //相机的位置
        Vector3 disPos = target.position + Vector3.up * distanceUp - target.forward * distanceAway;
        transform.position = Vector3.Lerp(transform.position, disPos, Time.deltaTime * smooth);
        //相机的角度
        transform.LookAt(target.position);
    }
}
