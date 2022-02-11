using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionSystemUiHandler : MonoBehaviour
{
    [SerializeField] SharedReactiveQuestion sharedQuestion;

    public void Answer(int index)
    {
        sharedQuestion.AnswerQuestion(index);
    }
}
