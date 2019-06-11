using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class updateKeys : MonoBehaviour
{

    public TextMeshProUGUI keyCount;

    // Start is called before the first frame update
    void Start()
    {
        
       keyCount.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
       int keys = PlayerPrefs.GetInt("NumKeys");
        keyCount.text = keys.ToString();
    }
}
