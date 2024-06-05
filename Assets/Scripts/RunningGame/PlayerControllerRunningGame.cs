using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControllerRunningGame : MonoBehaviour, IInteractable
{
    public PlayerInputControl inputControl;

    private Rigidbody2D rb;
    private PhysicsCheck physicsCheck;

    public Vector2 inoutDirection;

    public BoxCollider2D myBody;
    private bool isStinger;
    private bool isWin = false;
    public bool FinalWin = false;

    public GameObject WinCanvas;


    [Header("人物属性")]
    public float speed;
    public float jumpForce;
    public Transform playertransform;

    [Header("场景切换")]
    public SceneLoadEventSO loadEventSO;
    public GameSceneSO SceneToGo;
    public Vector3 positionToGo;


    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
        inputControl = new PlayerInputControl();
        myBody = GetComponent<BoxCollider2D>();
        playertransform = GetComponent<Transform>();

        inputControl.Gameplay.Jump.started += Jump;

    }



    private void OnEnable() {
        inputControl.Enable();
    }

    private void OnDisable() {
        inputControl.Disable();
    }

    private void Update() {
        inoutDirection = inputControl.Gameplay.Move.ReadValue<Vector2>();

    }

    private void FixedUpdate() {
        Move();
    }

    public void Move() {
        rb.velocity = new Vector2(inoutDirection.x * speed , rb.velocity.y);

        int faceDirection = (int)transform.localScale.x;

        if (inoutDirection.x > 0) {
            faceDirection = -1;
        } else if (inoutDirection.x < 0) {
            faceDirection = 1;
        }

        transform.localScale = new Vector3(faceDirection, 1, 1);
        CheckStinger();
        Die();
        CheckWin();
        Win();

    }

    private void Jump(InputAction.CallbackContext context) {
        // Debug.Log("JUMP");
        Debug.Log(physicsCheck.isGround);
        if(physicsCheck.isGround){
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    void CheckStinger() {
        isStinger = myBody.IsTouchingLayers(LayerMask.GetMask("Stinger"));
    }

    void Die() {
        if (isStinger) {
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            playertransform.position = positionToGo;
        }
    }

    void CheckWin() {
        isWin = myBody.IsTouchingLayers(LayerMask.GetMask("Win"));
    }
    void Win() {
        if (isWin) {
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            if (FinalWin)
            {
                if (WinCanvas != null && WinCanvas.activeInHierarchy == false)
                {
                    Debug.Log("Win");
                WinCanvas.SetActive(true);
                }
            }
            else loadEventSO.RaiseLoadRequestEvent(SceneToGo, positionToGo, true);
        }
    }

    public void TriggerAction()
    {
        Debug.Log("传送");

        loadEventSO.RaiseLoadRequestEvent(SceneToGo, positionToGo, true);

        Debug.Log("传送结束");
    }
}
