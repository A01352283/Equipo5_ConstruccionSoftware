using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public Text QuestionText;

    private void Start(){

    }

    public void correct(){
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers(){
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].answers[i];

            if(QnA[currentQuestion].correctanswer == i+1){
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }
    void generateQuestion(){
        currentQuestion = Random.Range(0, QnA.Count);
        QuestionText.text = QnA[currentQuestion].question;
        SetAnswers();
        QnA.RemoveAt(currentQuestion);
    }
}
