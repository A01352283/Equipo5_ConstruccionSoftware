using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public QuestionsList QnA;
    
    [SerializeField]
    private AudioSource audio_s;
    public AudioClip corr;
    public AudioClip incorr;
    public Text QuestionText;
    public Text Answer1Text;
    public Text Answer2Text;
    public Text Answer3Text;
    public Text Answer4Text;

    private QuestionAnswers currentQuestion;
    private int index =0;
    private int mult= 1;
    private int score= 0;

    public GameObject corr_screen;
    public GameObject incorr_screen;

    public bool match;

    public MemoryGameOverScreen TriviaGameOverScreen;
    public void GameOver(){
        GetComponent<Api_Scores>().UpdateScore(score);
        Debug.Log("Score Upated");
        TriviaGameOverScreen.Setup(score);
    }
    private void Start(){
        StartCoroutine(fillQuestion());
    }

    IEnumerator fillQuestion(){
        yield return new WaitForSeconds(2f);
        QnA=GetComponent<Api_Questions>().allQuestions;
        showQuestions();
    }
    public void showQuestions(){
        if(index<QnA.questions.Count){
            currentQuestion=QnA.questions[index];
            Debug.Log(currentQuestion.question);
            Debug.Log(currentQuestion.question_id);
            currentQuestion.AddList();
            Shuffle(currentQuestion.answers);
            QuestionText.text=currentQuestion.question;
            Answer1Text.text=currentQuestion.answers[0];
            Answer2Text.text=currentQuestion.answers[1];
            Answer3Text.text=currentQuestion.answers[2];
            Answer4Text.text=currentQuestion.answers[3];
        }
        else{
            GameOver();
        }
    }
    IEnumerator CheckMatch(bool _match){
        if(match){
            audio_s.clip=corr;
            corr_screen.SetActive(true);
            audio_s.Play();
            yield return new WaitForSeconds(.8f);
            corr_screen.SetActive(false);
            yield return new WaitForSeconds(.8f);
        }
        else{
            audio_s.clip=incorr;
            incorr_screen.SetActive(true);
            audio_s.Play();
            yield return new WaitForSeconds(.8f);
            incorr_screen.SetActive(false);
            yield return new WaitForSeconds(.8f);
        }
    }
    public void checkAns(int ans_index){
        if (currentQuestion.answers[ans_index]== currentQuestion.correctanswer){
            match=true;
            index++;
            Debug.Log("CORRECT");
            StartCoroutine(CheckMatch(match));
            score+=mult;
            mult = mult+(mult*1);
            if (mult>100){
                mult=100;
            }
            showQuestions();
        }
        else{
            match=false;
            index++;
            audio_s.clip=incorr;
            audio_s.Play();
            Debug.Log("INCORRECT");
            StartCoroutine(CheckMatch(match));
            mult=1;
            showQuestions();
        }
    }


    /*void SetAnswers(){
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].answers[i];

            if(QnA[currentQuestion].correctanswer == i+1){
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }
    */
    //We will latter generate the questions by json files

    //Function that allows to shuffle the order of the answers
    void Shuffle(List<string> s_list){
        for (int i = 0; i < s_list.Count; i++){
            string temp = s_list[i];
            int randomIndex= Random.Range(i, s_list.Count);
            s_list[i]=s_list[randomIndex];   
            s_list[randomIndex]= temp;     
        }
    }
}
