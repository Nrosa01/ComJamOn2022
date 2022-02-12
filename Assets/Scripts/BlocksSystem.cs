using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksSystem : MonoBehaviour
{
    [SerializeField] QuestionAssetGenerator questionGenerator;
    [SerializeField] SharedReactiveQuestion sharedQuestion;
    [SerializeField] GameObject[] blocksPrefabs;
    [SerializeField] AnimationCurve curve;
    [SerializeField] Transform blockInventory;
    int numOfCubes;


    [SerializeField] Bounds blockSpawnArea;
    [SerializeField] Vector3 origin;
    Camera cam;

    Vector3 GetOriginPoint() => blockSpawnArea.center + Camera.main.transform.position + origin;

    private void Awake()
    {
        cam = Camera.main;
        sharedQuestion.Initialize(questionGenerator);
        sharedQuestion.OnQuestionAnswered += OnAnswerChanged;
        SignalBus<SignalOnBecomeVisible>.Subscribe(OnCubeChange);
    }

    void OnAnswerChanged(bool isCorrect)
    {
        if (isCorrect)
        {
            SpawnBlock();
            //Debug.Log(isCorrect);
        }
    }
    void SpawnBlock()
    {
        Vector3 pointInBounds = blockSpawnArea.RandomPointInBounds();
        GameObject prefab = blocksPrefabs.GetRandom();
        var instantiated = Instantiate(prefab, GetOriginPoint(), Quaternion.identity);
        instantiated.transform.parent = blockInventory;
        MoveSpawnCube(instantiated.transform, pointInBounds).Forget();
    }

    async UniTaskVoid MoveSpawnCube(Transform transform, Vector3 point)
    {
        float dur = 0.25f;
        float timer = 0;

        while (timer < dur)
        {
            transform.position = Vector3.Lerp(GetOriginPoint(), point, curve.Evaluate(timer / dur));
            timer += Time.deltaTime;
            await UniTask.Yield();
        }

        transform.position = point;
    }

    void OnCubeChange(SignalOnBecomeVisible context)
    {
        if (context.isVisible) numOfCubes++;
        else numOfCubes--;

        if (numOfCubes <= 0)
        {
            // TODO
        }
    }

    private void OnDestroy()
    {
        SignalBus<SignalOnBecomeVisible>.Unsubscribe(OnCubeChange);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(blockSpawnArea.center + Camera.main.transform.position, blockSpawnArea.size);
        Gizmos.DrawWireSphere(blockSpawnArea.center + Camera.main.transform.position + origin, 0.25f);
    }
}
