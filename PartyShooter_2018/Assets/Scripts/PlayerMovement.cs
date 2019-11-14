using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;

    public float gravityForce;
    public float maxFallVelocity;

    public float jumpForce;
    public int allowedJumps;

    private Vector3 verticalMovement;
    private Vector3 horizontalMovement;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isGrounded;

    public Transform roofCheckPoint;
    public float roofCheckRadius;
    public LayerMask roofLayer;
    public bool isRoofed;

    private Rigidbody2D rB;
    
    private int jumpsMade;

    private bool jumpPressed;

    private string jump;
    private string moveHorizontal;

    private bool verVelReseted;

    private void Start()
    {
        rB = GetComponent<Rigidbody2D>();

        setInputNames();
        
    }
    private void Update()
    {
        if (GetComponent<PlayerHealth>().PlayerAlive)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
            isRoofed = Physics2D.OverlapCircle(roofCheckPoint.position, roofCheckRadius, roofLayer);

            if (Input.GetButtonDown(jump))
            {
                StartCoroutine(TrueJumpPressed());
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetComponent<PlayerHealth>().PlayerAlive)
        {
            horizontalMovement = new Vector3(0, 0, 0);

            if (gameObject.GetComponent<PlayerHealth>().PlayerAlive)
            {

                if (Input.GetAxis(moveHorizontal) < 0)
                {
                    horizontalMovement = new Vector3(-1, 0, 0);
                }
                if (Input.GetAxis(moveHorizontal) > 0)
                {
                    horizontalMovement = new Vector3(1, 0, 0);
                }


                if (isGrounded)
                {
                    if (verticalMovement.y < 0)
                    {
                        verticalMovement = new Vector3(0, 0, 0);

                        if (jumpsMade != 0)
                        {
                            jumpsMade = 0;
                        }
                        verticalMovement = new Vector3(0, 0, 0);
                    }
                }
                else
                {
                    if (isRoofed && !verVelReseted)
                    {
                        verticalMovement = new Vector3(0, 0, 0);
                        verVelReseted = true;
                    }
                    if (verticalMovement.y > maxFallVelocity)
                    {
                        verticalMovement -= new Vector3(0, gravityForce, 0);
                    }
                }
                if (verticalMovement.y > 5)
                {
                    verVelReseted = false;
                }

                if (jumpsMade < allowedJumps)
                {
                    if (jumpPressed)
                    {
                        verticalMovement = new Vector3(0, jumpForce, 0);

                        jumpsMade += 1;

                        jumpPressed = false;
                    }

                }

                rB.MovePosition(transform.position + (horizontalMovement * movementSpeed + verticalMovement) * Time.deltaTime);
            }
        }
    }

    IEnumerator TrueJumpPressed()
    {
        jumpPressed = true;

        yield return new WaitForSeconds(0.1f);

        jumpPressed = false;
    }
    public void setInputNames()
    {
        switch (gameObject.GetComponent<PlayerManager>().PlayerId)
        {
            case 0:
                jump = "P1Jump";
                moveHorizontal = "P1MoveHorizontal";
                break;
            case 1:
                jump = "P2Jump";
                moveHorizontal = "P2MoveHorizontal";
                break;
            case 2:
                jump = "P3Jump";
                moveHorizontal = "P3MoveHorizontal";
                break;
            case 3:
                jump = "P4Jump";
                moveHorizontal = "P4MoveHorizontal";
                break;
        }
    }
    private void OnDrawGizmos()
    {
        if (GetComponent<PlayerHealth>().PlayerAlive)
        {
            Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
            Gizmos.DrawWireSphere(roofCheckPoint.position, roofCheckRadius);
        }
    }
}
