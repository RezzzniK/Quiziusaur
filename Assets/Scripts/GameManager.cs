using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   Quiz quiz;
   EndGame endGame;
   //bool gameEnds=false;
   void Awake() {
        quiz=FindObjectOfType<Quiz>();
        endGame=FindObjectOfType<EndGame>();
   }
    void Start()
    {   
        Debug.Log("END SCENE:"+endGame.gameObject.active);
        Debug.Log("GM-START");
    
      
       
       
       endGame.gameObject.SetActive(false);
       quiz.gameObject.SetActive(true);
        Debug.Log("END SCENE:"+endGame.gameObject.active);
       //endGame.gameObject.active=false;
      // Debug.Log(endGame.gameObject.active);
       
    }
    private void Update() {
        if (quiz.getQUestQuant()==0){
            endGame.setScore();
            endGame.gameObject.SetActive(true);
            quiz.gameObject.SetActive(false);
        }
    }

 
}
