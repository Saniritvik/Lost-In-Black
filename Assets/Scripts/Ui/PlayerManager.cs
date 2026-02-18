using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    
    public GameObject Key;
    
    public GameObject Triangle;
    
    public GameObject Square;
    
    public GameObject Circle;
    
    public GameObject Hexagon;

    public GameObject Diamond;
    
    public int KeyCount;
    
    public bool AllowMove;
    
    public bool HasTriangle;
    
    public bool HasSquare;
    
    public bool HasCircle;
    
    public bool HasHexagon;

    public bool HasDiamond;
    
    public bool RoomOneGateActivate;
    
    public TextMeshProUGUI KeyCounter;
    
    public UnityEvent RoomOneGate;
    
    // Start is called before the first frame update
    void Start()
    {
        AllowMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        KeyCounter.text = KeyCount.ToString();
        CollectRoomOne();
    }
    public void KeyGrab()
    {
        KeyCount++;
        
        if (!Key.activeInHierarchy)
        {
            Key.SetActive(true);
        }
    }
    public void KeyUse()
    {
        KeyCount--;
        
        if (KeyCount == 0)
        { 
            Key.SetActive(false);
        }
    }
    public void TriangleGrab()
    {
        HasTriangle = true;
        Triangle.SetActive(true);
    }
    public void SquareGrab()
    {
        HasSquare = true;
        Square.SetActive(true);
    }
    public void CircleGrab()
    {
        HasCircle = true;
        Circle.SetActive(true);
    }
    public void HexagonGrab()
    {
        HasHexagon = true;
        Hexagon.SetActive(true);
    }
    public void DiamondGrab()
    {
        HasDiamond = true;
        Diamond.SetActive(true);
    }
    public void TriangleUse()
    {
        HasTriangle = false;
        Triangle.SetActive(false);
    }
    public void SquareUse()
    {
        HasSquare = false;
        Square.SetActive(false);
    }
    public void CircleUse()
    {
        HasCircle = false;
        Circle.SetActive(false);
    }
    public void HexagonUse()
    {
        HasHexagon = false;
        Hexagon.SetActive(false);
    }
    public void DiamondUse()
    {
        HasDiamond = false;
        Diamond.SetActive(false);
    }
    private void CollectRoomOne()
    {
        if(HasHexagon && HasSquare && HasCircle && !RoomOneGateActivate)
        {
            RoomOneGate.Invoke();
            RoomOneGateActivate = true;
        }
    }
}
