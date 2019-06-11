using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    Image thisImage;
	ImageChanger b1Script;
	ImageChanger b2Script;
	Room2Loop txtScript;

	//Enter the distance written on the tile in the inspector
	public int Distance;
	public Sprite original_sprite;
    public Sprite m_Sprite;
	public GameObject Button1;
	public GameObject Button2;
	public GameObject WhileLoopTxt;

	void Awake()
	{
		b1Script = Button1.GetComponent<ImageChanger>();
		b2Script = Button2.GetComponent<ImageChanger>();
	}

    void Start()
    {
        //Fetch the Image from the GameObject
        thisImage = GetComponent<Image>();

		//Fetch the script for controlling formula text
		txtScript = WhileLoopTxt.GetComponent<Room2Loop>();
    }

    public void Clicked()
    {
		//Convert sprite to image
    thisImage.sprite = m_Sprite;

		//2 different ways of referencing other objects
		//Resets other buttons
		Button1.GetComponent<ImageChanger>().Reset();
		b2Script.Reset();

    //Passes that button has been pressed to the Textbox controller
		txtScript.setFD(Distance);
    }

	public void Reset()
	{
		thisImage.sprite = original_sprite;
	}
}
