using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField]
    private float iniSpeed;
    [Tooltip("Idealmente valor entre 0.01 y 0.03")]
    private float acceleration = 0.01f;

    Rigidbody2D rb;
    float currSpeed;
    //TODO: When message for block placed, activate this component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, iniSpeed);
    }

    private void OnEnable()
    {
        //rb.velocity = new Vector2(0, iniSpeed);
    }

    void FixedUpdate()
    {
        rb.velocity += new Vector2(0f, acceleration) * Time.deltaTime;
    }
}
