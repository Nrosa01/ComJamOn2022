using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
   [SerializeField]private float iniSpeed;
   [SerializeField]private float endSpeed;
   [SerializeField]private float dur;
    private float timer;
    [Tooltip("Idealmente valor entre 0.01 y 0.03")]

    bool isMoving = false;

    void Start()
    {
        timer = 0.001f;
        SignalBus<SignalOnBlockPlaced>.Subscribe(OnSignalBlockPlaced);
    }

    void OnSignalBlockPlaced(SignalOnBlockPlaced signal)
    {
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving)
        {
            Vector2 currentSpeed = Vector2.up * Mathf.Lerp(iniSpeed, endSpeed, timer / dur);
            transform.Translate(currentSpeed * Time.deltaTime);
            timer += Time.deltaTime;
        }
    }

    private void OnDestroy()
    {
        SignalBus<SignalOnBlockPlaced>.Unsubscribe(OnSignalBlockPlaced);
    }
}
