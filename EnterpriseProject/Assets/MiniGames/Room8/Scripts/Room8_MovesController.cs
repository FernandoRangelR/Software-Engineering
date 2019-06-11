using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room8_MovesController : MonoBehaviour
{
	private bool winStatus;
	
	//Within Unity place the parent objects for each column
	public GameObject Column1_parent;
	public GameObject Column2_parent;
	public GameObject Column3_parent;
	public GameObject pet;
	public GameObject If_Options_Panel;
	
	//The parent script components to be taken from the game object above
	private Room8_MoveJoinSelection parent1;
	private Room8_MoveJoinSelection parent2;
	private Room8_MoveJoinSelection parent3;
	
	//Column 2 turning must be 270 for right, 90 for left, 0 for straight
	private int column1 = -1;
	private int column2 = -1;
	private int column3 = -1;
	
	private HandleMover petMover;
	
    // Start is called before the first frame update
    void Start()
    {
        winStatus = false;
		
		//Get parent components from objects
		parent1 = Column1_parent.GetComponent<Room8_MoveJoinSelection>();
		parent2 = Column2_parent.GetComponent<Room8_MoveJoinSelection>();
		parent3 = Column3_parent.GetComponent<Room8_MoveJoinSelection>();
		
		petMover = pet.GetComponent<HandleMover>();
		If_Options_Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		if(winStatus != true){
			column1 = parent1.getCurrent();
			column2 = parent2.getCurrent();
			column3 = parent3.getCurrent();
			winStatus_check();
		}
		else if(winStatus == true){
			enableIf();
		}
    }
	
	private void winStatus_check()
	{
		if(column1 == 3){
			if(column2 == 270){
				if(column3 == 3){
					winningMoves();
					winStatus = true;
				}
			}
			else if(column2 == 0){
				//TRAP SCRIPT HERE
			}
		}
	}
	
	private void winningMoves()
	{
		petMover.setMovesCount(2);
		petMover.Move(-3, 3);
		petMover.Move(-3, 0);
	}
	
	//void FixedUpdate()
	//{
	//}
	
	public bool getWinStatus()
	{
		return this.winStatus;
	}
	
	private void enableIf()
	{
		if (petMover.getCoroutineStatus() == false && petMover.getMovesCount() == 0){
			If_Options_Panel.SetActive(true);
		}
	}
}
