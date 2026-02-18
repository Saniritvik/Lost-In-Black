using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    public int AmountNeeded;
    public string SceneName;

    void Update()
    {
        if (AmountNeeded <= 0)
        {
            SceneManager.LoadSceneAsync(SceneName);
        }
    }
    public void skip()
    {
        AmountNeeded--;
    }

}
