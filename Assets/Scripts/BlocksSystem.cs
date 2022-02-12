using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksSystem : MonoBehaviour
{
    [SerializeField] QuestionAssetGenerator questionGenerator;
    [SerializeField] SharedReactiveQuestion sharedQuestion;
    [SerializeField] GameObject[] blocksPrefabs;
    int numOfCubes;


    [SerializeField]Bounds bounds;
    Camera cam;

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
        Vector3 pointInBounds = bounds.RandomPointInBounds();
        GameObject prefab = blocksPrefabs.GetRandom();
        Instantiate(prefab, pointInBounds, Quaternion.identity);
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
        Gizmos.DrawWireCube(bounds.center + Camera.main.transform.position, bounds.size);
    }
}
