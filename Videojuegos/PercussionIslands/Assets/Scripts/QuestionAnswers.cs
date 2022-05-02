//This script contains the class QuestioAnswer that contains each question with its respective answers
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class QuestionAnswers
{
    public int question_id;
    public string question;

    public string cor_answer;
    public string answer_2;
    public string answer_3;
    public string answer_4;
    public List<string> answers;
    public string correctanswer;

    public QuestionAnswers(int _questionid, string _question,string _ans1, string _ans2, string _ans3, string _ans4){
            this.question_id=_questionid;
            this.question = _question;
            this.cor_answer =_ans1;
            this.answer_2 = _ans2;
            this.answer_3 =_ans3;
            this.answer_4 =_ans4;
        }
    
    public void AddList(){
        this.correctanswer=this.cor_answer;
        this.answers.Add(this.cor_answer);
        this.answers.Add(this.answer_2);
        this.answers.Add(this.answer_3);
        this.answers.Add(this.answer_4);
    }
}


