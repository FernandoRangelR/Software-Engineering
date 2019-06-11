using UnityEngine;

public class Room11Loop : MonoBehaviour
{
    //closed is 0, open is 1
    private bool openorclosed = false;
    private int chestbutton = 0;

    //UI text which will be enabled/disabled
    public GameObject FOButton;
    public GameObject FCButton;
    public GameObject chest1;
    public GameObject chest2;
    public GameObject chest3;
    public GameObject chest4;
    public GameObject chest5;
    public GameObject chest6;

    private bool winStatus;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
        winStatus = false;
     }

    // Update is called once per frame
    void Update()
    {
        checkButton();
        CheckChestNumber();
    }

    void checkButton()
    {
        if (openorclosed == true) {
            FOButton.SetActive(true);
            FCButton.SetActive(false);
        }
        else if (openorclosed == false) {
            FOButton.SetActive(false);
            FCButton.SetActive(true);
        }
        else {
            FOButton.SetActive(false);
            FCButton.SetActive(false);
        }
        checkIfCorrect();
    }

    private void CheckChestNumber()
    {
        if (chestbutton == 1)
        {
            chest1.SetActive(true);
            chest2.SetActive(false);
            chest3.SetActive(false);
            chest4.SetActive(false);
            chest5.SetActive(false);
            chest6.SetActive(false);
        }
        else if (chestbutton == 2)
        {
            chest1.SetActive(false);
            chest2.SetActive(true);
            chest3.SetActive(false);
            chest4.SetActive(false);
            chest5.SetActive(false);
            chest6.SetActive(false);
        }
        else if (chestbutton == 3)
        {
            chest1.SetActive(false);
            chest2.SetActive(false);
            chest3.SetActive(true);
            chest4.SetActive(false);
            chest5.SetActive(false);
            chest6.SetActive(false);
        }
        else if (chestbutton == 4)
        {
            chest1.SetActive(false);
            chest2.SetActive(false);
            chest3.SetActive(false);
            chest4.SetActive(true);
            chest5.SetActive(false);
            chest6.SetActive(false);
        }
        else if (chestbutton == 5)
        {
            chest1.SetActive(false);
            chest2.SetActive(false);
            chest3.SetActive(false);
            chest4.SetActive(false);
            chest5.SetActive(true);
            chest6.SetActive(false);
        }
        else if (chestbutton == 6)
        {
            chest1.SetActive(false);
            chest2.SetActive(false);
            chest3.SetActive(false);
            chest4.SetActive(false);
            chest5.SetActive(false);
            chest6.SetActive(true);
        }
        else
        {
            chest1.SetActive(false);
            chest2.SetActive(false);
            chest3.SetActive(false);
            chest4.SetActive(false);
            chest5.SetActive(false);
            chest6.SetActive(false);
        }
        checkIfCorrect();
    }

    void Reset()
    {
        //fopen fclose buttons
        FOButton.SetActive(false);
        FCButton.SetActive(false);

        //chest buttons
        chest1.SetActive(false);
        chest2.SetActive(false);
        chest3.SetActive(false);
        chest4.SetActive(false);
        chest5.SetActive(false);
        chest6.SetActive(false);
    }

    public void SetButton(bool OpenOrClosed)
    {
        openorclosed = OpenOrClosed;
    }

    public void SetChestButton(int i)
    {
        chestbutton = i;
    }

    private void checkIfCorrect()
    {
        //const bool Win = true;
        if (openorclosed == true && chestbutton == 4 && winStatus == false)
        {
            ///winAnimation();
            winStatus = true;
        }
    }
}
