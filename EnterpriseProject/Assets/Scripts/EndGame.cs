using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{

  void OnTriggerEnter2D(Collider2D other){
    Debug.Log("EndGame 1");
    if(other.CompareTag("Player")){
      Debug.Log("EndGame 2");
      Application.Quit(0);
      Debug.Log("EndGame 3");
    }
  }

}
