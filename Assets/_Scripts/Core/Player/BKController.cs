/*
 Jonah W. Rabuck
*/

using UnityEngine;
using UnityEngine.InputSystem;

public class BKController : MonoBehaviour
{
    private BKState currentState;

    public BKState idleState;
    public BKState walkState;
    public BKState runState;
    public BKState jumpState;

    public float walkSpeed = 5f;
    public float runSpeed = 8f;

    [SerializeField] private Transform cameraTransform;
    [SerializeField] private CharacterController characterController;

    private Vector2 moveInput;
    private bool isJumping;
    private bool isRunning;

    void Start()
    {
        idleState = new BKIdleState(this);
        jumpState = new BKJumpState(this);
        walkState = new BKWalkState(this);

        ChangeState(idleState);
    }

    void Update()
    {
        currentState?.Update();
    }

    public void ChangeState(BKState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    // Input System Callbacks
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started) isJumping = true;
        if (context.canceled) isJumping = false;
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started) isRunning = true;
        if (context.canceled) isRunning = false;
    }

    // Helper Methods for States
    public bool IsMoving => moveInput != Vector2.zero;
    public bool IsJumping => isJumping;
    public bool IsRunning => isRunning;
    public Vector2 MoveInput => moveInput;
    public Transform CameraTransform => cameraTransform;
    public CharacterController CharacterController => characterController;

    public void SetAnimation(string anim)
    {
        GetComponent<Animator>().SetTrigger(anim);
    }
}
