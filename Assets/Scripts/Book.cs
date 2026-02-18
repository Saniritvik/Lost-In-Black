using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public GameObject Story;

    private void OnEnable()
    {
        Story.SetActive(true);
    }

}
