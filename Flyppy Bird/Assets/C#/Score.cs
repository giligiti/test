using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    public event Action ScoreEvent;//�÷��¼�
    public GameObject a;
    SceneChange SceneChange;
    private void Awake()
    {
        SceneChange = a.GetComponent<SceneChange>();
        ScoreEvent += SceneChange.TextUpgrate;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�����߹��м�͵��üӷ��¼�
        ScoreEvent();
    }
}
