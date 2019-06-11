using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room8_IfController : MonoBehaviour
{
	private bool winStatus;

	//Pet to be moved
	public GameObject pet;
	public GameObject Room8_Game_Manager;

	//Column 2 turning must be 270 for right, 90 for left, 0 for straight
	private bool column1 = false;
	private bool column2 = false;
	private float delayTime = 6f;

	//The script for physically moving the pet to a new location
	//The name comes from the door handle in Room2 - they both use this script
	//Originally I wrote a new script for the pet but it was overly complicated so I ended up reusing the HandleMover
	private HandleMover petMover;

	//Used for playing the winning jingle
	private AudioSource audioData;

	//This is just used for setting the win condition for the whole room
	private Room8_GameManager RM8_Manager;

    // Start is called before the first frame update
    void Start()
    {
        winStatus = false;

		//Get parent components from objects
		petMover = pet.GetComponent<HandleMover>();
		audioData = this.GetComponent<AudioSource>();
		RM8_Manager = Room8_Game_Manager.GetComponent<Room8_GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
		if(winStatus != true){
			winStatus_check();
		}else{
			Invoke("DelayedAction",delayTime);
		}
    }

		void DelayedAction(){
			if(SetPrefs.GetGame("PetComplete") == 0){
				PlayerPrefs.SetInt("NumKeys", PlayerPrefs.GetInt("NumKeys") + 1);
				SetPrefs.setGame("PetComplete");
			}
			SceneManager.LoadScene("Final Scene");
		}

	private void winStatus_check()
	{
		if(column1 == true){
			if(column2 == true){
				winningMoves();
				audioData.PlayDelayed(4f);
				winStatus = true;
				RM8_Manager.setWinStatus(true);
			}
		}
	}

	//Initiates the animation routine in the pets HandleMover class
	private void winningMoves()
	{
		petMover.setMovesCount(1);
		petMover.Move(-3, 3);
	}


	public void setColWin(int column, bool condition)
	{
		if(column == 1){
			this.column1 = condition;
		}
		else{
			this.column2 = condition;
		}
	}

	//void FixedUpdate()
	//{
	//}
}
