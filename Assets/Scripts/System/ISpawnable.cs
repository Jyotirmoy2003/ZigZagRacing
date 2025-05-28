using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnable 
{
    public float chance { get; set; }
    public GameObject Object{get;set;}
}
