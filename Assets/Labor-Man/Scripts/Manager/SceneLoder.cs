using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoder : SingletonMonoBehaviour<SceneLoder>
{
    [SerializeField]
    [Header("遷移したいシーンの名前")]
    string _nextSceneName;

    private void Start()
    {
        GameManager.Instance.OnClear += () => LoadScene(_nextSceneName);
    }

    void LoadScene(string str)
    {
        SceneManager.LoadSceneAsync(str);
    }
}
