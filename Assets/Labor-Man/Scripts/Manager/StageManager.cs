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

    [SerializeField]
    [Header("ステージのしきい値")]
    int _destroyPoint;

    [SerializeField]
    [Header("ステージの生成位置")]
    Transform _transform;

    [SerializeField]
    [Header("ステージの生成位置をどれくらいずらすか")]
    int _misaligned;

    GameObject[] _nextStages;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        StageMove();
    }

    void Init()
    {
        _nextStages[0] = Instantiate( _stages[0], _transform);
        _nextStages[0].transform.position = new Vector3(0, 0, 0);
        NextStageSet(1);
        NextStageSet();

    }

    void NextStageSet(int index = 2)
    {
        _nextStages[index] = Instantiate(_stages[Random.Range(0, _stages.Length)]);
        _nextStages[index].transform.localPosition = new Vector3(_nextStages[index - 1].transform.localPosition.x + _misaligned, 0, 0);
    }

    void StageMove()
    {
        for (int i = 0; i < _nextStages.Length; i++)
        {
            _nextStages[i].transform.position += new Vector3(-_scrollSpeed, 0, 0);
        }
        if (_nextStages[0].transform.localPosition.x > _destroyPoint)
        {
            StageCycle();
        }
    }
    void StageCycle()
    {
        Destroy(_nextStages[0]);
        _nextStages[0] = _nextStages[1];
        _nextStages[1] = _nextStages[2];
        NextStageSet();
    }
}
