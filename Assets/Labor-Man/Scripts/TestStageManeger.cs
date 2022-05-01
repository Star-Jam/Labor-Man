using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStageManeger : MonoBehaviour
{
    [SerializeField] float _fallSpeed = 0;
    [SerializeField] float _controle = 100;
    [SerializeField] float _stagePosition = 16;
    public GameObject[] stagePrefabs;

    public GameObject[] moveStage;

    public Transform parent;

    void Start()
    {
        moveStage[1] = Instantiate(stagePrefabs[Random.Range(0, stagePrefabs.Length)], parent);
        moveStage[1].transform.localPosition = new Vector3(moveStage[0].transform.localPosition.x + _stagePosition, 0, 0);
        moveStage[2] = Instantiate(stagePrefabs[Random.Range(0, stagePrefabs.Length)], parent);
        moveStage[2].transform.localPosition = new Vector3(moveStage[1].transform.localPosition.x + _stagePosition, 0,  0);
    }

    void Update()
    {
        for (int i = 0; i < moveStage.Length; i++)
        {
            moveStage[i].transform.localPosition += new Vector3(-_fallSpeed / _controle, 0, 0);
        }
        if (moveStage[0].transform.localPosition.x <= -_stagePosition - 1)
        {
            moveStage[0].gameObject.SetActive(false);
            moveStage[0] = moveStage[1];
            moveStage[1] = moveStage[2];
            moveStage[2] = Instantiate(stagePrefabs[Random.Range(0, stagePrefabs.Length)], parent);
            moveStage[2].transform.localPosition = new Vector3(moveStage[1].transform.localPosition.x + _stagePosition, 0, 0);
        }
    }
}
