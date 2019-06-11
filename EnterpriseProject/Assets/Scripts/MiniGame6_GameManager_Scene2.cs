using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MiniGame6_GameManager_Scene2 : MonoBehaviour
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
        // Swap();
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
                    //SceneManager.LoadScene("Room6_BinaryCardGame_Scene2");
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
                    //SceneManager.LoadScene("Room6_BinaryCardGame_Scene2");
                }
            }
        }


        for (int i = 0; i < c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().state = x;
            cards[c[i]].GetComponent<Card>().falseCheck();
        }

    }

    /*void Swap()
    {
        while (cards[0].GetComponent<Card>().transform.position != cards[7].GetComponent<Card>().transform.position)
        {
            float speed = 0.001f;
            float step = speed * Time.deltaTime;

            // move sprite towards the target location

            cards[0].GetComponent<Card>().transform.position = Vector2.MoveTowards(cards[0].GetComponent<Card>().transform.position,
                cards[7].GetComponent<Card>().transform.position, step);
            // Vector3 temp = cards[0].GetComponent<Card>().transform.position;
            // cards[0].GetComponent<Card>().transform.position = cards[7].GetComponent<Card>().transform.position;
            // cards[7].GetComponent<Card>().transform.position = temp;
        }
    }*/
}
