using UnityEngine;
using UnityEngine.UI;

public class NumberButtonHandler : MonoBehaviour
{
    Image thisImage;
    NumberButtonHandler b1script;
    NumberButtonHandler b2script;
    NumberButtonHandler b3script;
    NumberButtonHandler b4script;
    NumberButtonHandler b5script;
    Room11Loop textScript;


    public Sprite original_sprite;
    public Sprite pressed_sprite;

    public int whichChest;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject Button5;
    public GameObject LoopText;

    void Awake()
    {
        b1script = Button1.GetComponent<NumberButtonHandler>();
        b2script = Button2.GetComponent<NumberButtonHandler>();
        b3script = Button3.GetComponent<NumberButtonHandler>();
        b4script = Button4.GetComponent<NumberButtonHandler>();
        b5script = Button5.GetComponent<NumberButtonHandler>();
    }

    void Start()
    {
        thisImage = GetComponent<Image>();

        textScript = LoopText.GetComponent<Room11Loop>();
    }

    public void Clicked()
    {
        if (thisImage != null)
        {
            thisImage.sprite = pressed_sprite;
        }

        //Reset other buttons
        b1script.Reset();
        b2script.Reset();
        b3script.Reset();
        b4script.Reset();
        b5script.Reset();

        textScript.SetChestButton(whichChest);

    }

    public void Reset()
    {
        if (thisImage != null)
            thisImage.sprite = original_sprite;
    }
}
