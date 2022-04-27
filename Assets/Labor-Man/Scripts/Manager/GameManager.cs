using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    bool _isClear = false;
    bool _isGameOver = false;

    public bool Clear => _isClear;
    public bool GameOver => _isGameOver;

    Action _clear;
}
