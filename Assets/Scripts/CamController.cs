using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;

public class CamController : MonoBehaviour
{
    private Player playerTarget;

    CinemachineCamera virtualCamera;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTarget = FindAnyObjectByType<Player>();
        virtualCamera = GetComponent<CinemachineCamera>();

        virtualCamera.Follow = playerTarget.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
