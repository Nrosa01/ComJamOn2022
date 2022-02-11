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
        sharedQuestion.OnAnswerChanged += OnAnswerChanged;
    }

    private void OnDestroy()
    {
        sharedQuestion.OnAnswerChanged -= OnAnswerChanged;
    }

    void OnAnswerChanged(bool isCorrect)
    {
        if (isCorrect) SpawnBlock();
    }

    void SpawnBlock()
    {

    }
}
