﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void Retry()
    {
        GameManager.instance.RestartScene();
        gameObject.SetActive(false);
    }
}
