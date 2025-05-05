using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float BackGroundSpeed;//背景移动速度
    float BackGroundDistance;//背景移动距离
    float BackGroundMidDistance = 0;//中间状态移动距离
    Transform bkGround;//位置组件

    private void Awake()
    {
        BackGroundDistance = transform.position.x;
        bkGround = GetComponent<Transform>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void BkMove()
    {

        bkGround.transform.position += Vector3.left *BackGroundSpeed * Time.deltaTime;
        BackGroundMidDistance = bkGround.transform.position.x;
        if (BackGroundMidDistance <= 0)
        {
            bkGround.transform.position = new Vector3(BackGroundDistance,0,0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        BkMove();
    }
}
