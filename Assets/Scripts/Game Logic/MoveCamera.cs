using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField]
    private float iniSpeed;
    [Tooltip("Idealmente valor entre 0.01 y 0.03")]
    private float acceleration = 0.01f;

    bool isMoving = false;
    Rigidbody2D rb;
    float currSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, iniSpeed);
        SignalBus<SignalOnBlockPlaced>.Subscribe(OnSignalBlockPlaced);
    }

    void OnSignalBlockPlaced(SignalOnBlockPlaced signal)
    {
        isMoving = true;
    }

    void FixedUpdate()
    {
        if (isMoving)
            rb.velocity += new Vector2(0f, acceleration) * Time.deltaTime;
    }

    private void OnDestroy()
    {
        SignalBus<SignalOnBlockPlaced>.Unsubscribe(OnSignalBlockPlaced);
    }
}
