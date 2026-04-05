using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{ 
    [SerializeField] float speed = 5f;

    InputAction MoveAction;
    InputAction FireAction;

    [SerializeField] Vector2 minBound;
    [SerializeField] Vector2 maxBound;
    [SerializeField] float padding = 0.5f;
    [SerializeField] float Downpadding = 0.8f;
    [SerializeField] float UpPadding = 2.8f;

    Attack attack;
    Vector3 move;

    // 👉 Touch variables
    Vector2 lastTouchPos;
    bool isTouching;

    void Start()
    {
        attack = GetComponent<Attack>();

        MoveAction = InputSystem.actions.FindAction("Move");
        FireAction = InputSystem.actions.FindAction("Attack");

        MoveAction.Enable();
        FireAction.Enable();

        InitBounds();
    }

    void Update()
    {
        MovePlayer();
        FireShooter();
    }
     
    void InitBounds()
    {
        Camera Main = Camera.main;
        minBound = Main.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound = Main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void MovePlayer()
    {
        Vector2 input = MoveAction.ReadValue<Vector2>();

        // 📱 TOUCH OVERRIDE
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 currentTouch = Touchscreen.current.primaryTouch.position.ReadValue();

            if (!isTouching)
            {
                lastTouchPos = currentTouch;
                isTouching = true;
            }

            Vector2 delta = (currentTouch - lastTouchPos) * 0.01f;
            input = delta;

            lastTouchPos = currentTouch;
        }
        else
        {
            isTouching = false;
        }

        Vector3 newPos = transform.position + (Vector3)input * speed * Time.deltaTime;

        newPos.x = Mathf.Clamp(newPos.x, minBound.x + padding, maxBound.x - padding);
        newPos.y = Mathf.Clamp(newPos.y, minBound.y + Downpadding, maxBound.y - UpPadding);

        transform.position = newPos;
    }

    void FireShooter()
    {
        // 📱 TOUCH HOLD = FIRE
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            attack.isFiring = true;
        }
        else
        {
            attack.isFiring = FireAction.IsPressed();
        }
    }
}