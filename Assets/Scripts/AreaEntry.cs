using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntry : MonoBehaviour
{
    [SerializeField] string transitionAreaName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(transitionAreaName == Player.instance.transitionName)
        {
            Player.instance.transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
