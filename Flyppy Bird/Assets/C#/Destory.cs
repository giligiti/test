using System;
using UnityEngine;

public class Destory : MonoBehaviour
{
    public float speed = 0;//柱子移动速度
    
    private void FixedUpdate()
    {
        Move();//移动
        Des();//摧毁
    }
    private void Move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    private void Des()
    {
        
        //离开视口边界10f远就销毁
        if (transform.position.x <= Camera.main.ViewportToWorldPoint(Vector2.zero).x - 10f)
        {
            Destroy(gameObject);
        }
    }
}

