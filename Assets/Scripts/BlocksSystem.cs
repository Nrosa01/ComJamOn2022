using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlocksSystem : MonoBehaviour
{
    [SerializeField] QuestionAssetGenerator questionGenerator;
    [SerializeField] SharedReactiveQuestion sharedQuestion;
    int numOfCubes;

    private void Awake()
    {
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

    }

    void OnCubeChange(SignalOnBecomeVisible context)
    {
        if (context.isVisible) numOfCubes++;
        else numOfCubes--;

        if (numOfCubes <= 0)
        {
            // TODO
            Debug.Log("Game over");

            SceneManager.LoadScene("Game Over");
        }
    }
    
    private void OnDestroy()
    {
        SignalBus<SignalOnBecomeVisible>.Unsubscribe(OnCubeChange);
    }
}
