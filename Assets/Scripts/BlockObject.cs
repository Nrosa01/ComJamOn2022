using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockObject : MonoBehaviour
{
    [SerializeField]float newScale;
    [SerializeField] AnimationCurve curve;
    Vector2 initialScale;
    Rigidbody2D rb;
    Sprite sprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<Sprite>();
        initialScale = transform.localScale;
        rb.simulated = false;
    }

    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        this.enabled = false;
        rb.simulated = true;
    }

    private void OnMouseDown()
    {
        Debug.Log("Down");
        ScaleOverTime().Forget();
    }

    async UniTaskVoid ScaleOverTime()
    {
        float duration = 0.25f;
        float timer = 0;
        Vector3 finalScale = new Vector3(newScale, newScale, 0);

        while (timer < duration)
        {
            transform.localScale = Vector3.Lerp(initialScale, finalScale, curve.Evaluate(timer/duration)); // 0 - 1 0 - 0.25
            timer += Time.deltaTime;
            await UniTask.Yield();
        }
    }

    private void OnMouseDrag()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPos.x, newPos.y, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector2(newScale, newScale));
    }
}
