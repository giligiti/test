using System;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float SpaceTime ;//输入间隔
    public float FlyForce;//起飞力度
    public float GraForce;//下落速度

    Vector2 worldPosTopRight;
    Vector2 worldPosLeftBottom;
    float MidTime = 0f;//中转时间
    Rigidbody2D rb;//刚体组件
    bool start = false;//脚本组件启用标志
    float angule;//小鸟旋转角度
    public Transform bird;//获取子对象

    public event Action Dead = () => { Time.timeScale = 0; };//发布死亡事件
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.gravityScale = 0;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Dead();
    }
    public void ControlStart()
    {
        start = true;
        rb.gravityScale = GraForce;//启用重力
    }
    /// <summary>
    ///按键起飞
    /// </summary>
    void ShuRuff()
    {
        
        MidTime += Time.time;

        //按下按键起飞
        if (Input.GetKeyDown(KeyCode.Space) && MidTime >= SpaceTime)
        {
            MidTime = 0f;
            rb.linearVelocityY = FlyForce;
        }

    }
    /// <summary>
    /// 限制飞行区域
    /// </summary>
    void PositionCheck()
    {
        //获取视口范围
        worldPosTopRight = Camera.main.ViewportToWorldPoint(Vector2.one);
        worldPosLeftBottom = Camera.main.ViewportToWorldPoint(Vector2.zero);
        transform.position = new Vector2(transform.position.x, Mathf.Clamp( transform.position.y, worldPosLeftBottom.y-3f, worldPosTopRight.y-0.5f));
        if (transform.position.y == worldPosTopRight.y - 0.5f)
        {
            rb.linearVelocityY = 0f;
        }
    }
    //调整小鸟的角度
    void SetRotation()
    {
        angule = rb.linearVelocityY * 3;
        bird.transform.rotation = Quaternion.Euler(0f,0f,angule);
    }
    private void OnTriggerEnter(Collider other)
    {
        Dead();
    }
    void Update()
    {

        //手动控制起飞
        if (start)
        {
            ShuRuff();
        }

        //限制不超过顶部
        PositionCheck();
        
        //调整小鸟角度
        SetRotation();
    }
    
}
