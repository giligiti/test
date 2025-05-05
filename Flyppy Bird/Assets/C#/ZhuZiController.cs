using UnityEngine;

public class ZhuZiController : MonoBehaviour
{
    public GameObject[] ZhuZi;//柱子预制体
    public float ZhuZiSpeed;//柱子速度
    public float ZhuZiTime;//间隔时间
    float ZhuZiDisTime = 0;//间隔时间中间值
    
    private void FixedUpdate()
    {
        JianGe();
    }

    //间隔生成
    void JianGe()
    {
        ZhuZiDisTime += 1;
        if (Mathf.Approximately( ZhuZiDisTime,ZhuZiTime/0.02f ))
        {
            InsZhuZi();//生成移动的柱子
            ZhuZiDisTime = 0;
        }
    }
    //生成并且移动柱子
    void InsZhuZi()
    {
        float a = Random.Range(0.3f, 3.6f);//不同高度
        int b = Random.Range(0, 4);//不同柱子

        //生成柱子
        GameObject gb = Instantiate(ZhuZi[b],new Vector2(3,a),transform.rotation);

        //设定柱子速度
        Destory des = gb.GetComponent<Destory>();
        des.speed = ZhuZiSpeed;
    }
    
}
