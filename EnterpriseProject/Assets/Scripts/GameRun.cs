using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRun : MonoBehaviour
{
   public MoveBox SquareOne;
   public MoveBox SquareTwo;
   public MoveBox SquareThree;
   public MoveBox SquareFour;
   public int NumGoal;
   public int Total;

   public void Update(){
     if(GetTotal()){
       Debug.Log("YOU WIN");
     }
   }

   private bool GetTotal(){
    int ValOne, ValTwo, ValThree, ValFour;
    ValOne = ValTwo = ValThree = ValFour = 0;

     if(SquareOne.GetNumMoves() == 2){
       ValOne = SquareOne.Value;
     }
     if(SquareTwo.GetNumMoves() == 2){
       ValTwo = SquareTwo.Value;
     }
     if(SquareThree.GetNumMoves() == 2){
       ValThree = SquareThree.Value;
     }
     if(SquareFour.GetNumMoves() == 2){
       ValFour = SquareFour.Value;
     }

     Total = ValOne + ValTwo + ValThree + ValFour;
     if(Total == NumGoal){
       if(SetPrefs.GetGame("OverworldComplete") == 0){
         PlayerPrefs.SetInt("NumKeys", PlayerPrefs.GetInt("NumKeys") + 1);
         SetPrefs.setGame("OverworldComplete");
       }
       return true;
     }
     return false;
  }

}
