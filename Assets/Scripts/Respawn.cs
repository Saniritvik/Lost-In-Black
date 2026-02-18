
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3 RespawnerOne;
    public Vector3 RespawnerTwo;

    public Vector3 CheckPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        RespawnerOne = new Vector3(110, -9, 0);
        RespawnerTwo = new Vector3(110, -9, 0);
    }
    public void setCheckPointOne()
    {
        RespawnerOne = CheckPoint;
    }
    public void setCheckPointTwo()
    {
        RespawnerTwo = CheckPoint;
    }
    public void setCheckPointBoth()
    {
        RespawnerOne = CheckPoint;
        RespawnerTwo = CheckPoint;
    }
}
