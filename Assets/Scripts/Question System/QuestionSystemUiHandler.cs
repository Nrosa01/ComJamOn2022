using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionSystemUiHandler : MonoBehaviour
{
    [SerializeField] SharedReactiveQuestion sharedQuestion;

    [SerializeField] private Text question;
    [SerializeField] private Text[] answers;

    public void Answer(int index) => sharedQuestion.AnswerQuestion(index);

    private void Start()
    {
        question.text = sharedQuestion.GetCurrentQuestion.questionText;

        var answers = sharedQuestion.GetCurrentQuestion.answers;
        var numAnswer = answers.Length;

        for (int i = 0; i < 4; i++)
        {
            if (i < numAnswer) this.answers[i].text = answers[i].answer;
            this.answers[i].transform.parent.gameObject.SetActive(i < numAnswer);
        }

    }
}
