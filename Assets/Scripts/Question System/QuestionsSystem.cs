using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsSystem : MonoBehaviour
{
    [SerializeField] QuestionAssetGenerator questionGenerator;
    [SerializeField] SharedReactiveQuestion sharedQuestion;

    void Awake()
    {
        sharedQuestion.Initialize(questionGenerator);
        sharedQuestion.OnQuestionAnswered += OnAnswerChanged;
    }

    private void OnDestroy()
    {
        sharedQuestion.OnQuestionAnswered -= OnAnswerChanged;
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
}
