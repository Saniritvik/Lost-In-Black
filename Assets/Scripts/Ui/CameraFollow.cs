using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    
    public Transform target;
    public int y;
    public int x;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = new(target.position.x+x, target.position.y + y, transform.position.z);
        transform.position = playerPos;
        Vector2 cameraPosition = transform.position;
    }
}
