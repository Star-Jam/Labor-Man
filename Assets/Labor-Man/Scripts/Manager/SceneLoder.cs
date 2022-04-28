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

    void LoadScene(string name)
    {
        StartCoroutine(Load(name));
    }

    IEnumerator Load(string name)
    {
        print("開始");
        yield return SceneManager.LoadSceneAsync(name);
        print("終わり");
    }
}
