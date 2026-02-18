using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizer : MonoBehaviour
{
    public GameObject CameraObject;
    
    public float desiredHeight = 10f; // Set the desired height of the camera view
    
    public float desiredWidth = 16f; // Set the desired width of the camera view
    
    public float desiredY;
    
    public float desiredX;
    
    public bool test;
    
    private Camera CameraComponent;
    
    private Transform CameraTransform;

    void Start()
    {
        CameraTransform = CameraObject.GetComponent<Transform>();
        CameraComponent = CameraObject.GetComponent<Camera>();
        
        CameraComponent.orthographic = true; // Ensure the camera is in orthographic mode
    }
    private void Update()
    {
        if (test) 
        { 
            Camerasize();
        }
    }
    void SetCameraSize(float width, float height)
    {
        float aspectRatio = width / height;
        
        CameraComponent.orthographicSize = height / 2f;
        CameraComponent.aspect = aspectRatio;
    }
    public void Camerasize() 
    {
        CameraTransform.position = new Vector3(desiredX, desiredY);
        SetCameraSize(desiredWidth, desiredHeight);
    }
}
