using System;
using UnityEngine;

public class PlayerController
{
    enum Direction
    {
        Down = -1,
        Up = 1
    }

    public static PlayerController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerController();

            }

            return instance;
        }
    }

    private static PlayerController instance;

    private float maxSpeed;
    private float upAcceleration;
    private float downAcceleration;

    private Vector3 velocity = Vector3.zero;
    private Vector3 deltaMove = Vector3.zero;
    private Direction direction = Direction.Down;

    private GameObject player;
    private SpriteRenderer sprRend;
    private Rigidbody2D body;

    private int screenHeightBound;
    private float speed = 0;
    private float deltaTime = 0;
    private bool keyDown = false;

    private PlayerController()
    {
        Initialize();
    }

    private void Initialize()
    {
        maxSpeed = 1000f;
        upAcceleration = 1000f;
        downAcceleration = 2000f;

        player = UnityTool.FindGameObjectWithTag("Player");
        player.AddComponent<PlayerCollision>();
        body = player.GetComponent<Rigidbody2D>();
        sprRend = player.GetComponent<SpriteRenderer>();
    }

    public void Start()
    {
        Reset();
        player.transform.position = new Vector3(-640, 0, 0);
        screenHeightBound = (int)((Main.Instance.VisibleHeight - sprRend.bounds.size.y) / 2);
    }

    public void Update()
    {
        HandleKeyInput();

        deltaTime = Time.deltaTime;

        if (speed < maxSpeed)
        {
            if (keyDown)
            {
                speed += upAcceleration * Time.deltaTime;
            }
            else
            {
                speed += downAcceleration * Time.deltaTime;
            }
        }
        else
        {
            speed = maxSpeed;
        }

        body.velocity = player.transform.up * speed * (int)direction;
        CheckOOB();
    }

    private void HandleKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            keyDown = true;
            Reset();
            direction = Direction.Up;
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            keyDown = false;
            Reset();
            direction = Direction.Down;
        }
    }

    private void CheckOOB()
    {
        if (Math.Abs(player.transform.position.y) > screenHeightBound)
        {
            player.transform.position = new Vector3(-640, screenHeightBound * (int)direction, 0);
            GameStateController.Instance.SetState(new GamePauseState());
        }
    }

    private void Reset()
    {
        deltaTime = 0;
        speed = 0;
        velocity = Vector3.zero;
        deltaMove = Vector3.zero;
    }
}
