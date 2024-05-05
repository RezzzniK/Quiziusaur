using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
 [SerializeField] int startScore=100;
 int delimetr;
 public void initDelimetr(int quant) {
    delimetr=startScore/quant;
 }
  public int updateScore(){
     
    return startScore-=delimetr;
  }
  public int getScore(){
    return startScore;
  }
   
}
