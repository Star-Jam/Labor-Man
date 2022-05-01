using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : SingletonMonoBehaviour<StageManager>
{
    [SerializeField]
    [Header("スクロールするスピード")]
    float _scrollSpeed;

    [SerializeField]
    [Header("ステージのプレハブ")]
    GameObject[] _stages;

    string _avtiveSceneName;

    public string AvtiveSceneName => _avtiveSceneName;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        GetSceneName();
    }

    void GetSceneName()
    {
        _avtiveSceneName = SceneManager.GetActiveScene().name;
    }

    void Init()
    {
        _stages[0].transform.position = new Vector3(0, 0, 0);
        _stages[0].SetActive(true);
    }

    void NextStageSet()
    {
        _stages[Random.Range(0, _stages.Length)].transform.position = new Vector3(20, 0, 0);
    }

    void StageCycle()
    {

    }

    void RemoveStage()
    {

    }

    void AllFalse()
    {

    }
}
