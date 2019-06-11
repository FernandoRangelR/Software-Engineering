using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Vector3 PlayerPos;
    public string scene;
    private bool playerInRange;

    private void OnTriggerEnter2D(Collider2D other){
      PlayerPrefs.SetFloat("Y", other.transform.position.y);
      PlayerPrefs.SetFloat("X", other.transform.position.x);
      PlayerPrefs.SetFloat("Z", other.transform.position.z);

      if(other.CompareTag("Player")){
        playerInRange = true;
      }
    }

    private void OnTriggerExit2D(Collider2D other){
      if(other.CompareTag("Player")){
        playerInRange = false;
      }
    }

    public void Update(){
      if(playerInRange && Input.GetKey(KeyCode.Space)){
        MoveScene();
      }
    }

    public void MoveScene(){
      SceneManager.LoadScene(scene);
    }


}
