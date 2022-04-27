using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoder : MonoBehaviour
{
    [SerializeField]
    [Header("遷移したいシーンの名前")]
    string _nextSceneName;

    void LoadScene(string str)
    {
        SceneManager.LoadSceneAsync(str);
    }
}
