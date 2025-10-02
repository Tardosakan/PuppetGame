using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    [SerializeField] Rigidbody2D playerRigidBody;
    [SerializeField] Animator playerAnimator;
    [SerializeField] int moveSpeed = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        playerRigidBody.linearVelocity = new Vector2(horizontalMovement, verticalMovement) * moveSpeed;

        playerAnimator.SetFloat("movementX", playerRigidBody.linearVelocity.x);
        playerAnimator.SetFloat("movementY", playerRigidBody.linearVelocity.y);

        if(horizontalMovement == 1 || horizontalMovement == -1 || verticalMovement == 1 || verticalMovement == -1)
        {
            playerAnimator.SetFloat("lastX", horizontalMovement);
            playerAnimator.SetFloat("lastY", verticalMovement);
        }

    }
}
