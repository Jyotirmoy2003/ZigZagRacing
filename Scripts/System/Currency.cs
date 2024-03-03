using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public enum CurrencyType
    {
        Gem,
        Star,
    }

    [Range(0f,101f)]
    public float chance =10;
    public CurrencyType myType;
    [SerializeField] ParticleSystem particle;
    
    

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider info)
    {
        if(info.CompareTag("Player"))
        {
            Instantiate(particle,transform.position,Quaternion.identity);
            //add up currency and destroy
            CurrencyManager.instacne.AddCurency(this);
            Destroy(this.gameObject);
        }
    }
}
