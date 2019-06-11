﻿using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;  
using UnityEngine.SceneManagement;

public class MiniGame5GameManager : MonoBehaviour { 
  public GameObject nand, and, or, nandBlack, andBlack, orBlack;
    Vector2 nandInitialPosition, andInitialPosition, orInitialPosition;
    private int _matches = 3;

    void Start(){
        nandInitialPosition = nand.transform.position;
        andInitialPosition = and.transform.position;
        orInitialPosition = or.transform.position;
    }

    public void dragNand(){
        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = 100.0f; //distance of the plane from the camera
        nand.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }

    public void dragAnd(){
        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = 100.0f; //distance of the plane from the camera
        and.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }

    public void dragOr(){
        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = 100.0f; //distance of the plane from the camera
        or.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }

    public void dropNand(){
        float Distance = Vector3.Distance(nand.transform.position, nandBlack.transform.position);
        if(Distance < 1){
            nand.transform.position = nandBlack.transform.position;
            _matches--;
            if (_matches == 0)
            {
              if(SetPrefs.GetGame("LogicComplete") == 0){
                PlayerPrefs.SetInt("NumKeys", PlayerPrefs.GetInt("NumKeys") + 2);
                SetPrefs.setGame("LogicComplete");
              }

              SceneManager.LoadScene("Final Scene");
            }
        }
        else
        {
            nand.transform.position = nandInitialPosition;
        }
    }

    public void dropAnd(){
        float Distance = Vector2.Distance(and.transform.position, andBlack.transform.position);
        if (Distance < 1){
            and.transform.position = andBlack.transform.position;
            _matches--;
            if (_matches == 0)
            {
              if(SetPrefs.GetGame("LogicComplete") == 0){
                PlayerPrefs.SetInt("NumKeys", PlayerPrefs.GetInt("NumKeys") + 2);
                SetPrefs.setGame("LogicComplete");
              }
              SceneManager.LoadScene("Final Scene");
            }
        }
        else{
            and.transform.position = andInitialPosition;
        }
    }

    public void dropOr()
    {
        float Distance = Vector3.Distance(or.transform.position, orBlack.transform.position);
        if (Distance < 1)
        {
            or.transform.position = orBlack.transform.position;
            _matches--;
            if (_matches == 0)
            {
              if(SetPrefs.GetGame("LogicComplete") == 0){
                PlayerPrefs.SetInt("NumKeys", PlayerPrefs.GetInt("NumKeys") + 2);
                SetPrefs.setGame("LogicComplete");
              }
              SceneManager.LoadScene("Final Scene");
            }
        }
        else
        {
            or.transform.position = orInitialPosition;
        }
    }
}
