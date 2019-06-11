using UnityEngine;
using UnityEngine.UI;

public class RotationChanger : MonoBehaviour
{
    Image thisImage;
	RotationChanger b2Script;
	Room2Loop txtScript;
	
	
	//Rotation is 90 for left or 270 for right
	public int Rotation;
	public Sprite original_sprite;
    public Sprite new_Sprite;
	public GameObject Button2;
	public GameObject WhileLoopTxt;
	

	void Awake()
	{
		b2Script = Button2.GetComponent<RotationChanger>();
	}
	
    void Start()
    {
        //Fetch the original Image from the GameObject
        thisImage = GetComponent<Image>();
		
		//Fetch the script for controlling formula text
		txtScript = WhileLoopTxt.GetComponent<Room2Loop>();
    }

    public void Clicked()
    {
		//Convert sprite to image
        thisImage.sprite = new_Sprite;
		
		//Resets other buttons
		b2Script.Reset();
		
		txtScript.setRotate(Rotation);
    }
	
	public void Reset()
	{
		thisImage.sprite = original_sprite;
	}
}
