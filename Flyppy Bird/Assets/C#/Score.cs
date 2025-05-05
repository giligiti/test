using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    public event Action ScoreEvent;//得分事件
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
        //柱子走过中间就调用加分事件
        ScoreEvent();
    }
}
