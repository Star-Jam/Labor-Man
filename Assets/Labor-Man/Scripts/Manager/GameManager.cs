﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public bool Clear => _isClear;
    public bool GameOver => _isGameOver;

    bool _isClear = false;
    bool _isGameOver = false;

    /// <summary>ステージクリア時の処理を登録する</summary>
    public event Action OnClear;
    /// <summary>ゲームオーバー時の処理を登録する</summary>
    public event Action OnGameOver;
    /// <summary>ゲーム開始時の処理を登録する</summary>
    public event Action OnGameStart;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}
