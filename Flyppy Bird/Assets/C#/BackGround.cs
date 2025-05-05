using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float BackGroundSpeed;//�����ƶ��ٶ�
    float BackGroundDistance;//�����ƶ�����
    float BackGroundMidDistance = 0;//�м�״̬�ƶ�����
    Transform bkGround;//λ�����

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
