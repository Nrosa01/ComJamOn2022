using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestionSystemUiHandler : MonoBehaviour
{
    private const int TIME_BETWEEN_QUESTIONS = 3000;
    private int GetQuestionDuration => Mathf.FloorToInt(sharedQuestion.GetCurrentQuestion.questionDuration * 1000);

    [SerializeField] SharedReactiveQuestion sharedQuestion;

    [SerializeField] private Text question;
    [SerializeField] private Text[] answers;
    [SerializeField] private Text questionTimeText;
    [SerializeField] private Image profeImage;
    [SerializeField] private GameObject questionBlockContainer;
    int timer = 0;

    private CancellationTokenSource source;

    public void Answer(int index) => sharedQuestion.AnswerQuestion(index);

    private void Start()
    {
        sharedQuestion.OnQuestionAnswered += OnAnswered;
        UpdateUI();
        source = new CancellationTokenSource();
        QuestionTimeout(source.Token).Forget();
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

        Sprite profeSprite = sharedQuestion.GetCurrentQuestion.profeSprite;
        if (profeSprite != null) profeImage.sprite = profeSprite;
    }

    private void OnDestroy()
    {
        sharedQuestion.OnQuestionAnswered -= OnAnswered;
        source.Cancel();
        source.Dispose();
    }

    async private UniTaskVoid QuestionTimeout(CancellationToken cancellation)
    {
        await UniTask.Delay(GetQuestionDuration, DelayType.UnscaledDeltaTime, PlayerLoopTiming.Update, cancellation);
        if(!cancellation.IsCancellationRequested)OnAnswered();
    }

    private void OnAnswered(bool isCorrect = false)
    {
        OnAnsweredTask(isCorrect).Forget();
    }

    async private UniTaskVoid OnAnsweredTask(bool isCorrect = false)
    {
        GenericExtensions.CancelAndGenerateNew(ref source);
        questionBlockContainer.SetActive(false);
        await UniTask.Delay(TIME_BETWEEN_QUESTIONS, DelayType.UnscaledDeltaTime, PlayerLoopTiming.Update, source.Token);
        questionBlockContainer.SetActive(true);
        NextQuestion();
        QuestionTimeout(source.Token).Forget();
    }

    void NextQuestion()
    {
        sharedQuestion.NextQuestion();
        UpdateUI();
    }
}
