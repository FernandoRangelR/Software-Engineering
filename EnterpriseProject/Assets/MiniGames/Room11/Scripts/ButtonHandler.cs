using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    Image thisImage;
    ButtonHandler b1script;
    Room11Loop textScript;

    public Sprite original_sprite;
    public Sprite pressed_sprite;

    public bool OpenOrClose;
    public GameObject Button1;
    public GameObject LoopText;


    void Awake()
    {
        b1script = Button1.GetComponent<ButtonHandler>();
    }

    void Start()
    {

        //get Image from the GameObject
        thisImage = GetComponent<Image>();

        //get script to control the formula text
        textScript = LoopText.GetComponent<Room11Loop>();
    }

    public void Clicked()
    {
        //convert sprite to image
        thisImage.sprite = pressed_sprite;

        //reset other button
        Button1.GetComponent<ButtonHandler>().Reset();

        //pass which button has been pressed to textbox
        textScript.SetButton(OpenOrClose);
    }

    public void Reset()
    {
        if (thisImage != null)
        {
            thisImage.sprite = original_sprite;
        }
    }
}
