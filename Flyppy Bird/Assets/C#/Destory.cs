using System;
using UnityEngine;

public class Destory : MonoBehaviour
{
    public float speed = 0;//�����ƶ��ٶ�
    
    private void FixedUpdate()
    {
        Move();//�ƶ�
        Des();//�ݻ�
    }
    private void Move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    private void Des()
    {
        
        //�뿪�ӿڱ߽�10fԶ������
        if (transform.position.x <= Camera.main.ViewportToWorldPoint(Vector2.zero).x - 10f)
        {
            Destroy(gameObject);
        }
    }
}

