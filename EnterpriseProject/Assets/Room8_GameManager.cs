using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room8_GameManager : MonoBehaviour
{
	//Main game manager for room 8 mini game. 
	//Really just stores win state which will be written to by the Room8_IfController on its completion
	
	private bool Room8_winStatus;
	
    // Start is called before the first frame update
    void Start()
    {
        Room8_winStatus = false;
    }
	
	public void setWinStatus(bool status)
	{
		Room8_winStatus = status;
	}
	
	public bool getWinStatus()
	{
		return Room8_winStatus;
	}
	
}
