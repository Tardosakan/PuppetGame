using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField] Rigidbody2D playerRigidBody;
    [SerializeField] Animator playerAnimator;

    [SerializeField] int moveSpeed = 1;

    public string transitionName;

    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;

    [SerializeField] Tilemap tilemap;

    // Called when the script instance is being loaded
    void Awake()
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bottomLeftEdge = tilemap.localBounds.min;
        topRightEdge = tilemap.localBounds.max;
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

        transform.position = new Vector3(
           Mathf.Clamp(transform.position.x, bottomLeftEdge.x, topRightEdge.x),
           Mathf.Clamp(transform.position.y, bottomLeftEdge.y, topRightEdge.y),
           Mathf.Clamp(transform.position.z, bottomLeftEdge.z, topRightEdge.z)
        );

    }
}
