using UnityEngine;
using UnityEngine.UI;

public class Room8_MoveButtonChanger : MonoBehaviour
{
    Image thisImage;
	Room8_MoveButtonChanger b1Script;
	Room8_MoveButtonChanger b2Script;
	Room8_MoveJoinSelection parent;
	//Room8_MovesController Controller;
	
	//Enter the distance written on the tile in the inspector
	public int Distance;
	public Sprite Original_sprite;
    public Sprite Pressed_Sprite; 
	public GameObject Button1;
	public GameObject Button2;
	
	public GameObject Parent_Selection_Keeper;
	//public GameObject Move_controller; 

	void Awake()
	{
		b1Script = Button1.GetComponent<Room8_MoveButtonChanger>();
		b2Script = Button2.GetComponent<Room8_MoveButtonChanger>();
		parent = Parent_Selection_Keeper.GetComponent<Room8_MoveJoinSelection>();
	}
	
    void Start()
    {
        //Fetch the Image from the GameObject
        thisImage = GetComponent<Image>();
		
		//Fetch the script for controlling formula text
		//Controller = Move_controller.GetComponent<Room8_MovesController>(); 
    }

    public void Clicked()
    {
		//Convert sprite to image
        thisImage.sprite = Pressed_Sprite;
		
		//2 different ways of referencing other objects
		//Resets other buttons
		Button1.GetComponent<Room8_MoveButtonChanger>().Reset();
		b2Script.Reset();
		
		parent.setCurrent(Distance);
		
		//txtScript.setFD(Distance); SET FOR TEXT
    }
	
	public void Reset()
	{
		thisImage.sprite = Original_sprite;
	}
}
