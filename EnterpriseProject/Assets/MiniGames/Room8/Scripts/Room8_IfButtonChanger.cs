using UnityEngine;
using UnityEngine.UI;

public class Room8_IfButtonChanger : MonoBehaviour
{
    Image thisImage;
	Room8_IfButtonChanger b1Script;
	Room8_IfButtonChanger b2Script;
	Room8_IfController controller;
	
	private bool clicked;
	
	//In the inspector select whether this is the correct button for that column
	//Column number must be 1 or 2, any number higher than 2 is treated as 2, refactor controller for more columns
	public bool Winner;
	public int Column_Number;
	public Sprite Original_sprite;
    public Sprite Pressed_Sprite; 
	public GameObject Button1;
	public GameObject Button2;
	
	public GameObject If_Controller;

	void Awake()
	{
		b1Script = Button1.GetComponent<Room8_IfButtonChanger>();
		b2Script = Button2.GetComponent<Room8_IfButtonChanger>();
		controller = If_Controller.GetComponent<Room8_IfController>();
	}
	
    void Start()
    {
        //Fetch the Image from the GameObject
        thisImage = GetComponent<Image>();
		
		this.clicked = false; 
    }

    public void Clicked()
    {
		//Convert sprite to image
        thisImage.sprite = Pressed_Sprite;
		
		//2 different ways of referencing other objects
		//Resets other buttons
		Button1.GetComponent<Room8_IfButtonChanger>().Reset();
		b2Script.Reset();
		this.clicked = true;
		
		//Passes click to the If section controller
		controller.setColWin(Column_Number, Winner);
		
		//txtScript.setFD(Distance); SET FOR TEXT
    }
	
	public void Reset()
	{
		thisImage.sprite = Original_sprite;
		this.clicked = false;
	}
	
	public bool getStatus()
	{
		return this.clicked;
	}
}
