using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room2Loop : MonoBehaviour
{
	//Turn is 270 for right, 90 for left
	private int fd = -1;
	private int turn = 0;

	//The UI text overlay objects which will be enabled/disabled
	public GameObject FD_T0;
	public GameObject FD_T5;
	public GameObject FD_T6;
	public GameObject FD_TR;
	public GameObject FD_TL;
	public GameObject HandleObject;
	private float delayTime = 5f;

	private HandleMover hScript;
	private AudioSource audioData;
	private bool winStatus;


    // Start is called before the first frame update
    void Start()
    {
		Reset();
		winStatus = false;
		hScript = HandleObject.GetComponent<HandleMover>();
		audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
		enableFD();
		enableRotate();
    }

	void enableFD()
	{
		if(fd == 0){
			FD_T5.SetActive(false);
			FD_T6.SetActive(false);
			FD_T0.SetActive(true);
		}
		else if(fd == 5){
			FD_T0.SetActive(false);
			FD_T6.SetActive(false);
			FD_T5.SetActive(true);
		}
		else if(fd == 6){
			FD_T0.SetActive(false);
			FD_T5.SetActive(false);
			FD_T6.SetActive(true);
		}
		else{
			FD_T0.SetActive(false);
			FD_T5.SetActive(false);
			FD_T6.SetActive(false);
		}
		checkWin();
	}

	void enableRotate()
	{
		if(turn == 90){
			FD_TR.SetActive(false);
			FD_TL.SetActive(true);
		}
		else if(turn == 270){
			FD_TL.SetActive(false);
			FD_TR.SetActive(true);
		}
		else{
			FD_TL.SetActive(false);
			FD_TR.SetActive(false);
		}
		checkWin();
	}

	void Reset()
	{
    FD_T0.SetActive(false);
		FD_T5.SetActive(false);
		FD_T6.SetActive(false);
		FD_TR.SetActive(false);
		FD_TL.SetActive(false);
	}

	public void setFD(int a)
	{
		fd = a;
	}

	public void setRotate(int a)
	{
		turn = a;
	}

	private void checkWin()
	{
		if(fd == 5 && turn == 270 && winStatus == false){
		winAnimation();
		winStatus = true;
		Invoke("DelayedAction",delayTime);
		}

	}

	void DelayedAction(){
		if(SetPrefs.GetGame("HandleComplete") == 0){
			PlayerPrefs.SetInt("NumKeys", PlayerPrefs.GetInt("NumKeys") + 1);
			SetPrefs.setGame("HandleComplete");
		}

		SceneManager.LoadScene("Final Scene");
	}

	public bool getwinStatus()
	{
		return winStatus;
	}

	//These coordinates are seemingly in reverse order because they get passed to a stack before rendering
	//Final (top) coordinate has to be more than 0 or nothing happens but its actually returning to origin
	private void winAnimation()
	{
		hScript.Move(0f, 0.001f);
		hScript.Move(0f, -3.2f);
		hScript.Move(3.2f, -3.2f);
		hScript.Move(3.2f, 0f);
		audioData.PlayDelayed(3f);
	}
}
