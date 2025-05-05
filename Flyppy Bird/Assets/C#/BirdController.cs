using System;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float SpaceTime ;//������
    public float FlyForce;//�������
    public float GraForce;//�����ٶ�

    Vector2 worldPosTopRight;
    Vector2 worldPosLeftBottom;
    float MidTime = 0f;//��תʱ��
    Rigidbody2D rb;//�������
    bool start = false;//�ű�������ñ�־
    float angule;//С����ת�Ƕ�
    public Transform bird;//��ȡ�Ӷ���

    public event Action Dead = () => { Time.timeScale = 0; };//���������¼�
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
        rb.gravityScale = GraForce;//��������
    }
    /// <summary>
    ///�������
    /// </summary>
    void ShuRuff()
    {
        
        MidTime += Time.time;

        //���°������
        if (Input.GetKeyDown(KeyCode.Space) && MidTime >= SpaceTime)
        {
            MidTime = 0f;
            rb.linearVelocityY = FlyForce;
        }

    }
    /// <summary>
    /// ���Ʒ�������
    /// </summary>
    void PositionCheck()
    {
        //��ȡ�ӿڷ�Χ
        worldPosTopRight = Camera.main.ViewportToWorldPoint(Vector2.one);
        worldPosLeftBottom = Camera.main.ViewportToWorldPoint(Vector2.zero);
        transform.position = new Vector2(transform.position.x, Mathf.Clamp( transform.position.y, worldPosLeftBottom.y-3f, worldPosTopRight.y-0.5f));
        if (transform.position.y == worldPosTopRight.y - 0.5f)
        {
            rb.linearVelocityY = 0f;
        }
    }
    //����С��ĽǶ�
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

        //�ֶ��������
        if (start)
        {
            ShuRuff();
        }

        //���Ʋ���������
        PositionCheck();
        
        //����С��Ƕ�
        SetRotation();
    }
    
}
