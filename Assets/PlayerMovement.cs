using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private CharacterController characterController;

    [SerializeField]
    private Transform camTransform;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float moveSpeed = 6f;

    [SerializeField]
    private float runningMoveSpeed = 10f;

    [SerializeField]
    private float turnSmoothTime = .1f;

    [SerializeField]
    private Vector3 velocity;


    [Tooltip("The character uses its own gravity value. The engine default is -9.81f")]
    [SerializeField]
    private float Gravity = -9.81f;

    [Header("Player Grounded")]
    [Tooltip("If the character is grounded or not. Not part of the CharacterController built in grounded check")]
    [SerializeField]
    private bool isGrounded = true;

    [Tooltip("Useful for rough ground")]
    [SerializeField]
    private float GroundedOffset = -0.14f;

    [Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
    [SerializeField]
    private float GroundedRadius = 0.28f;

    [Tooltip("What layers the character uses as ground")]
    [SerializeField]
    private LayerMask GroundLayers;


    //private bool isGrounded = true;
    private bool isRunning = false;
    private float turnSmoothVelocity;
    private float _verticalVelocity;
    private float _terminalVelocity = 53.0f;


    // Start is called before the first frame update
    void Start()
    {
        playIdleAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.isPaused)
        {
            HandleGravity();
            GroundedCheck();
            HandleMoveAndAnimations();
        }
    }

    private void HandleGravity()
    {
        if (isGrounded)
        {
            if (_verticalVelocity < 0.0f)
            {
                _verticalVelocity = -2f;
            }
        }
        else
        {
            // apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
            if (_verticalVelocity < _terminalVelocity)
            {
                _verticalVelocity += Gravity * Time.deltaTime;
            }
        }

    }

    private void GroundedCheck()
    {
        // set sphere position, with offset
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset,
            transform.position.z);
        isGrounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers,
            QueryTriggerInteraction.Ignore);

    }

    private void HandleMoveAndAnimations()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        isRunning = Input.GetKey(KeyCode.LeftShift);
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (isRunning && direction.magnitude >= .1f)
        {
            HandleMovementAndRotation(direction, runningMoveSpeed);
            playRunAnimation();
        }
        else if (direction.magnitude >= .1f)
        {
            HandleMovementAndRotation(direction, moveSpeed);
            playWalkAnimation();
        }
        else
        {
            playIdleAnimation();
        }
    }

    private void HandleMovementAndRotation(Vector3 direction, float moveSpeed)
    {
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camTransform.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        // move the player
        characterController.Move(moveDir.normalized * (moveSpeed * Time.deltaTime) +
                         new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);
    }

    private void playIdleAnimation()
    {
        if (animator != null)
        {
            animator.Play("Idle_A");
        }
    }

    private void playWalkAnimation()
    {
        animator.Play("Walk");
    }

    private void playRunAnimation()
    {
        animator.Play("Run");
    }

}
