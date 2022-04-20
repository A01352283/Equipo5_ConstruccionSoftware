
using System.Collections;
using System.Collections.Generic;
[System.Serializable]

public class QuestionAnswers
{
    public string question;
    public List<string> answers;
    public string correctanswer;

    public QuestionAnswers(string _question,string _ans1, string _ans2, string _ans3, string _ans4){
            this.question = _question;
            this.answers.Add(_ans1);
            this.answers.Add(_ans2);
            this.answers.Add(_ans3);
            this.answers.Add(_ans4);
            this.correctanswer = _ans1;
        }
}


