using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveBox: MonoBehaviour
{
  public GameObject box;
  public Vector3 moveDown;
  public Vector3 moveUp;
  public Text diaglogText;
  public string dialog;
  public bool playerInRange;
  private double YPos;
  public double BoxPos;
  private int NumMoves = 0;
  private int up = 0;
  private int down = 1;
  public int Value;

  private void OnTriggerEnter2D(Collider2D other){
    if(other.CompareTag("Player")){
      playerInRange = true;
      YPos = other.transform.position.y;
      BoxPos = transform.position.y;
    }
  }

  public int GetNumMoves(){
    return NumMoves;
  }

  private void OnTriggerExit2D(Collider2D other){
    if(other.CompareTag("Player")){
      playerInRange = false;
    }
  }

  private void Update(){
    if(Input.GetKey(KeyCode.Space) && playerInRange == true){
      if(YPos > BoxPos){
        if(ValidPos(down) == true){
           transform.Translate(moveDown);
           NumMoves--;
        }
      }
      else if(ValidPos(up) == true){
        NumMoves++;
        transform.Translate(moveUp);
      }
    }
  }

  private bool ValidPos(int UpDown){
    if(NumMoves <= 2 && NumMoves >= 1 && UpDown == 1){
      return true;
    }
    else if(NumMoves <= 1 && NumMoves >= 0 && UpDown == 0){
      return true;
    }
    return false;
  }
}
