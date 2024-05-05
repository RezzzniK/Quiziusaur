using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;//to be able to accsses textMeshPro elements
public class Quiz : MonoBehaviour
{   
    [Header("Questions:")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] List<ColorsQuestionsSO> questions=new List<ColorsQuestionsSO>();
     ColorsQuestionsSO currentQuestionsSO;
    [Header("Answers:")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    bool answeredEarly;
    [Header("Button sprites:")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [Header("Timer image:")]
    [SerializeField] Image timerImg;
    Timer timer;
    Score score;
    Slider slider;
    bool scoreUpdated;

    public void Awake(){

      timer=FindObjectOfType<Timer>();  
      score=FindObjectOfType<Score>();
      slider=FindObjectOfType<Slider>();
    }
    public void Start()
    {
      Debug.Log("QUIZ START");
     
      slider.maxValue=questions.Count;
      slider.value=0;
      score.initDelimetr(questions.Count);
      getRandomQuestion();
      DisplayQuestion();
      scoreUpdated=false;
    }
    void Update(){

        timerImg.fillAmount =timer.getFillFraction();   
        if(timer.loadNextQuestion){
            timer.cancleTimer();
            answeredEarly=false;
            if(questions.Count!=0){
                getNextQuestion();
                timer.loadNextQuestion=false;

            }
        }else if(!answeredEarly&&!timer.isAnsweringQuestion){
            displayAnswer(-1);
            setButtonState(false);
        }
        //Debug.Log("" + timer.getFillFraction());
    }
  
    void DisplayQuestion(){
          questionText.text = currentQuestionsSO.GetQuestion();
        TextMeshProUGUI buttonText;
        for (int i = 0; i < answerButtons.Length; i++)
        {
            buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestionsSO.GetAnswer(i);

        }
        correctAnswerIndex=currentQuestionsSO.GetRightAnswerIndex();
        slider.value++;

    }
    void getNextQuestion(){
        getRandomQuestion();
        setDefaultButtonsSprite();
        setButtonState(true);
        DisplayQuestion();
        timer.startTimer();
        scoreUpdated=false;
    }
    void getRandomQuestion(){
        int index=Random.Range(0,questions.Count);
        currentQuestionsSO=questions[index];
        if(questions[index]==currentQuestionsSO){
            questions.RemoveAt(index);
        }
    }
    public void onAnswerSelected(int index)
    {
       answeredEarly=true;
        displayAnswer(index) ;
        setButtonState(false);
        timer.cancleTimer();
    }

    void displayAnswer(int index){
         if (correctAnswerIndex == index)
        {
            questionText.text="Correct";
            Image image = answerButtons[index].GetComponent<Image>();
            image.sprite=correctAnswerSprite;


        }else{
            questionText.text="Incorrect Answer, right answer is: "+currentQuestionsSO.GetAnswer(correctAnswerIndex);
               Image image = answerButtons[correctAnswerIndex].GetComponent<Image>();
            image.sprite=correctAnswerSprite;
            if(!scoreUpdated){
                scoreText.GetComponentInChildren<TextMeshProUGUI>().text="Score: "+score.updateScore().ToString()+"%";
                scoreUpdated=true;
            }
        }
    }
     
    void setButtonState(bool state){
        foreach (var button in answerButtons){
            button.GetComponent<Button>().interactable=state;
        }
    }
    void setDefaultButtonsSprite(){
           foreach (var button in answerButtons){
            button.GetComponent<Image>().sprite = defaultAnswerSprite;
        }
    }
    public int getQUestQuant(){
        return questions.Count;
    }
}
