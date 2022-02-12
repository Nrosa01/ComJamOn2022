using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITransicion : MonoBehaviour
{
    [SerializeField] RectTransform left;
    [SerializeField] RectTransform right;
    [SerializeField] AnimationCurve curve;

    [SerializeField] float distance;
    [SerializeField] float duration;

    void Start()
    {
        StartLerp().Forget();
    }

    async UniTaskVoid StartLerp()
    {
        await UniTask.Delay(500);
        Lerp(left, left.anchoredPosition, left.anchoredPosition + Vector2.left * distance, curve, duration).Forget();
        Lerp(right, right.anchoredPosition, right.anchoredPosition + Vector2.right * distance, curve, duration).Forget();
        SignalBus<PlaySoundSignal>.Fire(new PlaySoundSignal(Sounds.UITransition, 1));
    }
    
    public async UniTask EndLerp()
    {
        await UniTask.Delay(500);
        var task1 = Lerp(left, left.anchoredPosition, left.anchoredPosition - Vector2.left * distance, curve, duration);
        var task2 = Lerp(right, right.anchoredPosition, right.anchoredPosition - Vector2.right * distance, curve, duration);
        SignalBus<PlaySoundSignal>.Fire(new PlaySoundSignal(Sounds.UITransition, 1));
        await task1;
        await task2;
    }

    async UniTask Lerp(RectTransform transform, Vector3 initPos, Vector3 endPos, AnimationCurve curve, float duration)
    {
        float time = 0;

        while (time < duration)
        {
            transform.anchoredPosition = Vector3.Lerp(initPos, endPos, curve.Evaluate(time / duration));
            time += Time.deltaTime;
            await UniTask.Yield();
        }

        transform.anchoredPosition = endPos;
    }
}
