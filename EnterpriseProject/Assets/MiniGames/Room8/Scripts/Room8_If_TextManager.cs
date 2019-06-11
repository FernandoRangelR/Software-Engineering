using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room8_If_TextManager : MonoBehaviour
{
	//Button objects and their scripts
	private Room8_IfButtonChanger EButtonScript;
	private Room8_IfButtonChanger NEButtonScript;
	private Room8_IfButtonChanger LTButtonScript;
	private Room8_IfButtonChanger KeyButtonScript;
	private Room8_IfButtonChanger OcButtonScript;
	private Room8_IfButtonChanger ChaButtonScript;
	
	public GameObject Equals_Button;
	public GameObject NotEquals_Button;
	public GameObject LessThan_Button;
	public GameObject Keys_Button;
	public GameObject Ocarina_Button;
	public GameObject Chains_Button;
	
	//Text objects in the Textbox
	public GameObject Equals_Text;
	public GameObject NotEquals_Text;
	public GameObject LessThan_Text;
	public GameObject Keys_Text;
	public GameObject Ocarina_Text;
	public GameObject Chains_Text;
	
    // Start is called before the first frame update
    void Start()
    {
        EButtonScript = Equals_Button.GetComponent<Room8_IfButtonChanger>();
		NEButtonScript = NotEquals_Button.GetComponent<Room8_IfButtonChanger>();
		LTButtonScript = LessThan_Button.GetComponent<Room8_IfButtonChanger>();
		KeyButtonScript = Keys_Button.GetComponent<Room8_IfButtonChanger>();
		OcButtonScript = Ocarina_Button.GetComponent<Room8_IfButtonChanger>();
		ChaButtonScript = Chains_Button.GetComponent<Room8_IfButtonChanger>();
    }

    // Update is called once per frame
    void Update()
    {
		SymbolText();
		PickupText();
    }
	
	private void SymbolText()
	{
		if(EButtonScript.getStatus() == true){
			Equals_Text.SetActive(true);
		}
        if(NEButtonScript.getStatus() == true){
			NotEquals_Text.SetActive(true);
		}
        if(LTButtonScript.getStatus() == true){
			LessThan_Text.SetActive(true);
		}
	}
	
	private void PickupText()
	{
		if(KeyButtonScript.getStatus() == true){
			Keys_Text.SetActive(true);
		}
        if(OcButtonScript.getStatus() == true){
			Ocarina_Text.SetActive(true);
		}
        if(ChaButtonScript.getStatus() == true){
			Chains_Text.SetActive(true);
		}
	}	
	
	//This is much shorter and more efficient than the previous method used in Room 2 which reset all other buttons when one was clicked
	//Add this to each respective buttons click event in the Unity inspector, it will be called on each click
	public void resetSymbolsText()
	{
		Equals_Text.SetActive(false);
		NotEquals_Text.SetActive(false);
		LessThan_Text.SetActive(false);
	}
	
	//Add this to each respective buttons click event in the Unity inspector, it will be called on each click
	public void resetPickupsText()
	{
		Keys_Text.SetActive(false);
		Ocarina_Text.SetActive(false);
		Chains_Text.SetActive(false);
	}
	
}
