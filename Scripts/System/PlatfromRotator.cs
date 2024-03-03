using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromRotator : MonoBehaviour
{
    [SerializeField] Transform platfromTransform;
    [SerializeField] float rotationSpeed=4f;

    void Start()
    {
        if(platfromTransform==null)
        {
            platfromTransform=GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        platfromTransform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
