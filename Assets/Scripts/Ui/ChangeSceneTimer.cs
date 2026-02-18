using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTimer : MonoBehaviour
{
    public float Timeleft;
    public string SceneName;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timeleft = Timeleft - Time.deltaTime;
        if (Timeleft <= 0) 
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
