using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room8_MoveJoinSelection : MonoBehaviour
{
	//Column 2 turning must be 270 for right, 90 for left, 0 for straight
	private int current = -1;
	
    // Start is called before the first frame update
    public void setCurrent(int i)
    {
		current = i;
    }

    // Update is called once per frame
    public int getCurrent()
    {
        return current;
    }
}
