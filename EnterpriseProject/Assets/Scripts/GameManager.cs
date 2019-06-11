using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Sprite[] cardFace;
    public Sprite cardBack;
    public GameObject[] cards;

    private bool _init = false;
    private int _matches = 4;

    // Update is called once per frame
    void Update()
    {
        if (!_init)
            initializeCards();

        if (Input.GetMouseButtonUp(0))
            checkCards();

    }

    void initializeCards()
    {
        for (int i = 1; i < 9; i++)
        {
            bool test = false;
            int choice = 0;
            while (!test)
            {
                choice = Random.Range(0, cards.Length);
                test = !(cards[choice].GetComponent<Card>().initialized);
            }
            cards[choice].GetComponent<Card>().cardValue = i;
            cards[choice].GetComponent<Card>().initialized = true;
        }

        foreach (GameObject c in cards)
            c.GetComponent<Card>().setupGraphics();

        if (!_init)
            _init = true;
    }

    public Sprite getCardBack()
    {
        return cardBack;
    }

    public Sprite getCardFace(int i)
    {
        return cardFace[i - 1];
    }

    void checkCards()
    {
        List<int> c = new List<int>();

        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].GetComponent<Card>().state == 1)
                c.Add(i);
        }

        if (c.Count == 2)
            cardComparison(c);
    }

    void cardComparison(List<int> c)
    {
        Card.DO_NOT = true;

        int x = 0;

        if (cards[c[0]].GetComponent<Card>().cardValue % 2 == 0)
        {
            if (cards[c[0]].GetComponent<Card>().cardValue == (cards[c[1]].GetComponent<Card>().cardValue + 1))
            {
                x = 2;
                _matches--;
                if (_matches == 0)
                {
                  if(SetPrefs.GetGame("CardComplete") == 0) {
                    PlayerPrefs.SetInt("NumKeys", PlayerPrefs.GetInt("NumKeys") + 1);
                    SetPrefs.setGame("CardComplete");
                  }
                  SceneManager.LoadScene("Final Scene");
                }
            }
        }
        else
        {
            if (cards[c[0]].GetComponent<Card>().cardValue == (cards[c[1]].GetComponent<Card>().cardValue - 1))
            {
                x = 2;
                _matches--;
                if (_matches == 0)
                {
                  if(SetPrefs.GetGame("CardComplete") == 0) {
                    PlayerPrefs.SetInt("NumKeys", PlayerPrefs.GetInt("NumKeys") + 1);
                    SetPrefs.setGame("CardComplete");
                  }
                  SceneManager.LoadScene("Final Scene");
                }
            }
        }


        for (int i = 0; i < c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().state = x;
            cards[c[i]].GetComponent<Card>().falseCheck();
        }

    }
}
