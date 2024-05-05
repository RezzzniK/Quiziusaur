using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    Score scoreValue;
    [SerializeField] TextMeshProUGUI endTitle;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject button;
    int totalScore;
    void Awake() {
        scoreValue=FindObjectOfType<Score>();
    }
    void Start()
    {
        
       

    }


    public void onReplayClicked(){
        SceneManager.LoadScene(0);
    }
    public void setScore(){
         Debug.Log("IN END SCRIPT");
        Debug.Log(scoreValue.getScore());
        totalScore=scoreValue.getScore();   
        if(totalScore>50){
            endTitle.GetComponent<TextMeshProUGUI>().text="Congratulations!";
            scoreText.GetComponent<TextMeshProUGUI>().text="Your score is: "+totalScore.ToString()+"%"; 
        }else{
            endTitle.GetComponent<TextMeshProUGUI>().text="Game Over";
              scoreText.GetComponent<TextMeshProUGUI>().text="Your score is: "+totalScore.ToString(); 
        }
    }
  
}
