//This script contains the class QuestioAnswer that contains each question with its respective answers
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class QuestionAnswers
{
    public int question_id;
    public string question;

    public string ans1;
    public string ans2;
    public string ans3;
    public string ans4;
    public List<string> answers;
    public string correctanswer;

    public QuestionAnswers(int _questionid, string _question,string _ans1, string _ans2, string _ans3, string _ans4){
            this.question_id=_questionid;
            this.answers=new List<string>();
            this.question = _question;
            this.answers.Add(_ans1);
            this.answers.Add(_ans2);
            this.answers.Add(_ans3);
            this.answers.Add(_ans4);
            this.correctanswer = _ans1;
        }
    public void AddList(){
        this.answers=new List<string>();
        this.answers.Add(ans1);
        this.answers.Add(ans2);
        this.answers.Add(ans3);
        this.answers.Add(ans4);
    }
}


