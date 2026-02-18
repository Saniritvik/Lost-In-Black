using NUnit.Framework;
using System.Runtime;
using UnityEngine;
[System.Serializable]

public class Weopons
{
    public string name;
    public GameObject weopon;
    public float firing;
    public int damage;
    public enum styles { tap, hold, charge}
    public styles firingType; 
}
