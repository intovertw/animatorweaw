using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public float targetSpeed, walkSpeed, runSpeed;
    public bool isRun, isWalk;

    public Animator animator;
    public CharacterController characterController;
    public PlayerInput playerInput;

    public Vector2 moveInput;
    // Start is called before the first frame update
    private void OnEnable()
    {
        playerInput = new PlayerInput();
        playerInput.PlayerActionMap.playerActionGlobal.performed += PlayerActionGlobal_performed;
        playerInput.PlayerActionMap.playerActionGlobal.canceled += PlayerActionGlobal_canceled;
        playerInput.PlayerActionMap.jump.performed += Jump_performed;
        playerInput.Enable();
    }

    private void Jump_performed(InputAction.CallbackContext obj)
    {
        moveInput = obj.ReadValue<Vector2>();
        throw new System.NotImplementedException();
    }

    private void PlayerActionGlobal_canceled(InputAction.CallbackContext obj)
    {
        moveInput = obj.ReadValue<Vector2>();
        throw new System.NotImplementedException();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void PlayerActionGlobal_performed(InputAction.CallbackContext obj)
    {
        moveInput = obj.ReadValue<Vector2>();
        throw new System.NotImplementedException();
    }

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Move()
    {
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        moveDirection = transform.TransformDirection(moveDirection)*targetSpeed;
        animator.SetFloat("speed", moveInput.magnitude);
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
