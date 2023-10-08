using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float _speed;
    private float touchX;
    private float newX;
    public float xSpeed;
    public float limitX;

    private Rigidbody rb;      
    private Animator animator;  
    private bool isJumping = false; 

    public float jumpForce = 3f;

    public GameObject jumpTarget;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        MovePlayer();

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Jump();
        }
    }
    private void Jump()
    {
        animator.SetTrigger("Jump");
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isJumping = true;
    }
    public void OnJumpAnimationEnd()
    {
        isJumping = false;
    }
    private void MovePlayer()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchX = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            touchX = Input.GetAxis("Mouse X");
        }
        else
        {
            touchX = 0;
        }


        newX = transform.position.x + xSpeed * touchX * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);
        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + _speed * Time.deltaTime);
        transform.position = newPosition;
    }
}
