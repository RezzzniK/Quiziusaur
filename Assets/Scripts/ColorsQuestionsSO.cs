using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Question_1", menuName = "ColorsQuestionsSO")]
public class ColorsQuestionsSO : ScriptableObject {
    [TextArea(2,6)]
    [SerializeField] string question_1="What the color of Sun?";
    [SerializeField] string [] answers=new string[4];
    [SerializeField] int rightAnswer;
    public string GetQuestion()
    {
        return question_1;
    }
    public int GetRightAnswerIndex(){
        return rightAnswer;
    }
    public string GetAnswer(int index){
        return answers[index];
    }
    public int GetAnswersLenght()
    {
        return answers.Length;
    }
  
}

// public class Test{
//     ColorsQuestionsSO test;
//     public void Testi(){
//         Debug.Log(test.GetQuestion());
//     }
// }