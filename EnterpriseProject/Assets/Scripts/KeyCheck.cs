using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCheck : MonoBehaviour
{
  public GameObject keychecker;

  void OnCollisionEnter2D(Collision2D col){

    int NumKeys = PlayerPrefs.GetInt("NumKeys");
    Debug.Log(NumKeys);
    if(NumKeys == 2 && col.gameObject.tag == "Player"){
      PlayerPrefs.SetInt("NumKeys", 0);
            keychecker.SetActive(false);
    }
  }
}
