using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("监听事件")]
    public SceneLoadEventSO loadEvent;
    public VoidEventSO afterSceneLoadedEvent;
    public PlayerInputControl inputControl;

    private Rigidbody2D rb;

    public Vector2 inoutDirection;

    public float speed;


    private void Awake()
    {
        inputControl = new PlayerInputControl();

        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        inputControl.Enable();
        loadEvent.LoadRequestEvent += OnLoadEvent;
        afterSceneLoadedEvent.OnEventRaised += OnAfterSceneLoadedEvent;
    }

    private void OnDisable()
    {
        inputControl.Disable();
        loadEvent.LoadRequestEvent -= OnLoadEvent;
        afterSceneLoadedEvent.OnEventRaised -= OnAfterSceneLoadedEvent;
    }

    private void Update()
    {
        inoutDirection = inputControl.Gameplay.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        rb.velocity = new Vector2(inoutDirection.x, inoutDirection.y).normalized * speed;

        int faceDirection = (int)transform.localScale.x;

        if (inoutDirection.x > 0)
        {
            faceDirection = -1;
        }
        else if (inoutDirection.x < 0)
        {
            faceDirection = 1;
        }

        transform.localScale = new Vector3(faceDirection, 1, 1);
    }

    private void OnLoadEvent(GameSceneSO sceneToLoad, Vector3 positionToGo, bool fadeScreen)
    {
        inputControl?.Gameplay.Disable();
    }

    private void OnAfterSceneLoadedEvent()
    {
        inputControl?.Gameplay.Enable();
    }
}
