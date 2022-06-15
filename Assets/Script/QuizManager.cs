using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QnA> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject QuizPanel;
    public GameObject CorrectPanel;
    public GameObject WrongPanel;

    public Text ScoreTextCorrect;
    public Text ScoreTextWrong;
    public static int score;

    public Text QuestionText;
    private void Start()
    {
        generateQuestion();
        CorrectPanel.SetActive(false);
        WrongPanel.SetActive(false);
    }

   
    public void correct()
    {
        //QnA.RemoveAt(currentQuestion);
        Debug.Log("correct");
        score += 10;
        ScoreTextCorrect.text = "Nilai kamu "+score;
        generateQuestion(); 
        QuizPanel.SetActive(false);
        CorrectPanel.SetActive(true);
    }

    public void wrong()
    {
        Debug.Log("wrong");
        ScoreTextWrong.text = "Nilai kamu " + score;
        generateQuestion();
        QuizPanel.SetActive(false);
        WrongPanel.SetActive(true);
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        //currentQuestion = Random.Range(0, QnA.Count);

        QuestionText.text = QnA[currentQuestion].Question;
        SetAnswers();
    }
}
