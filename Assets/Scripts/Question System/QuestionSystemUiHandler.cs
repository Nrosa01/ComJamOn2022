using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class QuestionSystemUiHandler : MonoBehaviour
{
    private const int TIME_BETWEEN_QUESTIONS = 1000;
    private int GetQuestionDuration => Mathf.FloorToInt(sharedQuestion.GetCurrentQuestion.questionDuration * 1000);


    [SerializeField] SharedReactiveQuestion sharedQuestion;

    [SerializeField] private Text question;
    [SerializeField] private Text[] answers;
    [SerializeField] private Text questionTimeText;
    int timer = 0;

    private CancellationTokenSource source;

    public void Answer(int index) => sharedQuestion.AnswerQuestion(index);

    private void Start()
    {
        sharedQuestion.OnQuestionAnswered += OnAnswered;
        UpdateUI();
        source = new CancellationTokenSource();
        QuestionTimeout(source.Token);
    }

    private void Update()
    {
        timer -= (int)(Time.deltaTime * 1000);
        questionTimeText.text = Mathf.FloorToInt(timer/1000 + 1).ToString();
    }

    void UpdateUI()
    {
        timer = GetQuestionDuration;

        question.text = sharedQuestion.GetCurrentQuestion.questionText;

        var answers = sharedQuestion.GetCurrentQuestion.answers;
        var numAnswer = answers.Length;

        for (int i = 0; i < 4; i++)
        {
            if (i < numAnswer) this.answers[i].text = answers[i].answer;
            this.answers[i].transform.parent.gameObject.SetActive(i < numAnswer);
        }
    }

    private void OnDestroy()
    {
        sharedQuestion.OnQuestionAnswered -= OnAnswered;
        source.Cancel();
        source.Dispose();
    }

    async private void QuestionTimeout(CancellationToken cancellation)
    {
        await UniTask.Delay(GetQuestionDuration, DelayType.Realtime, PlayerLoopTiming.Update, cancellation);
        if(!cancellation.IsCancellationRequested)OnAnswered();
    }

    async private void OnAnswered(bool isCorrect = false)
    {
        GenericExtensions.CancelAndGenerateNew(ref source);
        question.gameObject.SetActive(false);
        await UniTask.Delay(TIME_BETWEEN_QUESTIONS);
        question.gameObject.SetActive(true);
        NextQuestion();
        QuestionTimeout(source.Token);
    }

    void NextQuestion()
    {
        sharedQuestion.NextQuestion();
        UpdateUI();
    }
}
