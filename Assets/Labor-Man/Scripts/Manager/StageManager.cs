using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : SingletonMonoBehaviour<StageManager>
{
    string _avtiveSceneName;

    public string AvtiveSceneName => _avtiveSceneName;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _avtiveSceneName = SceneManager.GetActiveScene().name;
    }
}
