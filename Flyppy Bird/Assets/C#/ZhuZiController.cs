using UnityEngine;

public class ZhuZiController : MonoBehaviour
{
    public GameObject[] ZhuZi;//����Ԥ����
    public float ZhuZiSpeed;//�����ٶ�
    public float ZhuZiTime;//���ʱ��
    float ZhuZiDisTime = 0;//���ʱ���м�ֵ
    
    private void FixedUpdate()
    {
        JianGe();
    }

    //�������
    void JianGe()
    {
        ZhuZiDisTime += 1;
        if (Mathf.Approximately( ZhuZiDisTime,ZhuZiTime/0.02f ))
        {
            InsZhuZi();//�����ƶ�������
            ZhuZiDisTime = 0;
        }
    }
    //���ɲ����ƶ�����
    void InsZhuZi()
    {
        float a = Random.Range(0.3f, 3.6f);//��ͬ�߶�
        int b = Random.Range(0, 4);//��ͬ����

        //��������
        GameObject gb = Instantiate(ZhuZi[b],new Vector2(3,a),transform.rotation);

        //�趨�����ٶ�
        Destory des = gb.GetComponent<Destory>();
        des.speed = ZhuZiSpeed;
    }
    
}
