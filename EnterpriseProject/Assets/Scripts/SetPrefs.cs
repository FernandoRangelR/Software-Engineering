using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPrefs : MonoBehaviour
{
   public static int count = 0;
   private static int CardComplete = 0;
   private static int LogicComplete = 0;
   private static int HandleComplete = 0;
   private static int PetComplete = 0;
   private static int OverworldComplete = 0;

   public static int CheckCount(){
     return count;
   }

   public static void SetCount(){
     count++;
   }

   public static void setGame(string game){
     switch(game){
       case "CardComplete":
         CardComplete++;
         break;
      case "LogicComplete":
         LogicComplete++;
         break;
     case "HandleComplete":
         HandleComplete++;
         break;
     case "PetComplete":
         PetComplete++;
         break;
     case "OverworldComplete":
         OverworldComplete++;
         break;
     }
   }

   public static int GetGame(string game){
     if(string.Compare("CardComplete",game) == 0){
       return CardComplete;
     }
     if(string.Compare("LogicComplete",game) == 0){
       return LogicComplete;
     }
     if(string.Compare("HandleComplete",game) == 0){
       return HandleComplete;
     }
     if(string.Compare("PetComplete",game) == 0){
       return PetComplete;
     }
     if(string.Compare("OverworldComplete",game) == 0){
       return OverworldComplete;
     }
     return 0;
   }
}
