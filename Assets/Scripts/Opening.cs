﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Opening : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayBGM(4);
    }

    // Update is called once per frame
    void Update()
    {
       


    }
    /*
    public void GameStart()
    {

        SceneManager.LoadScene("SampleScene");
    }
    */



}
