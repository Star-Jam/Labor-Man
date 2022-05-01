using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : SingletonMonoBehaviour<StageManager>
{
    public string AvtiveSceneName => _avtiveSceneName;

    [SerializeField]
    [Header("スクロールするスピード")]
    float _scrollSpeed;

    [SerializeField]
    [Header("ステージのプレハブ")]
    GameObject[] _stages;

    [SerializeField]
    [Header("ステージのしきい値")]
    Transform _destroyPoint;

    string _avtiveSceneName;

    GameObject[] _nextStages;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        GetSceneName();
        Init();
    }

    private void Update()
    {
        NextStageSet();
        StageMove();
    }

    void GetSceneName()
    {
        _avtiveSceneName = SceneManager.GetActiveScene().name;
    }

    void Init()
    {
        _nextStages[0] = _stages[0];
        _nextStages[0].transform.position = new Vector3(0, 0, 0);
        _nextStages[0].SetActive(true);
    }

    void NextStageSet()
    {
        _nextStages[2] = _stages[Random.Range(0, _stages.Length)];
    }

    void StageCycle()
    {
        _nextStages[0] = _nextStages[1];
        _nextStages[1] = _nextStages[2];
    }

    void StageMove()
    {
        for (int i = 0; i < _nextStages.Length; i++)
        {
            _nextStages[i].transform.position += new Vector3(_scrollSpeed, 0, 0);
        }
        //if(_nextStages[0].transform.position > )
        //{
        //    StageCycle();
        //}
    }
}
