using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
enum Scene
{
    one,
    two,
    three,
    four,
}
public class SceneChange : MonoBehaviour
{
    public GameObject First;
    public GameObject Second;
    public GameObject scendobject;//�������������壬���ڶ����¼�
    public Number rb;//��ȡscendobject�ű�����
    public GameObject Third;
    Text text;//��ó������Ӷ����ϵ�Text���
    public GameObject Fours;

    public GameObject Player;//���С�����
    private Animator animator;//С�񶯻�������
    BirdController birdController;//���С�����ϵĽű�

    
    GameObject Now;//��ʾ��ǰ����
    GameObject before;//��ʾǰһ������
    Scene scene;//��ʾ��ǰ�����ı��
    
    private void Awake()
    {
        scene = Scene.four;
        Now = Fours;

        rb = scendobject.GetComponent<Number>();
        
        animator = Player.GetComponentInChildren<Animator>();
        birdController = Player.GetComponentInChildren<BirdController>();
        text = Third.GetComponentInChildren<Text>();
        text.text = "0";
        //���ĸ����¼�
        EventFouces();

        //��ʧ��
        First.SetActive(true);
        Second.SetActive(false);
        Third.SetActive(false);
        Fours.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator.SetInteger("State", 0);//��ʼ��״̬��
        OnClick();
    }

    #region �л�����
    /// <summary>
    /// ѡ�񳡾�
    /// </summary>
    void Select()
    {
        before = Now;
        switch (scene)
        {
            case Scene.one:
                Now = First;
                break;
            case Scene.two:
                Now = Second;
                break;
            case Scene.three:
                Now = Third;
                break;
            case Scene.four:
                Now = Fours;
                break;
            default:
                Debug.LogWarning("������");
                break;
        }
        Space();
    }
    /// <summary>
    /// �����л�����
    /// </summary>
    public void OnClick()
    {
        //���������ǰ+1
        scene += 1;

        //������������
        if (scene > Scene.four)
        {
            scene = Scene.one;
        }
        Select();
        
    }
    
    /// <summary>
    /// �л�����
    /// </summary>
    /// <param name="n"></param>
    void Space()
    {
        before.SetActive(false);
        Now.SetActive(true);
    }
    #endregion

    #region ����״̬�ı�

    /// <summary>
    /// ����״̬��ǰ�ƽ�
    /// </summary>
    public void AnimationChange()//���¿�ʼ��Ϸ��
    {
        int a = animator.GetInteger("State");
        a += 1;
        animator.SetInteger("State", a );
    }


    #endregion
    //�÷����ӷ���
    public void TextUpgrate()
    {
        int t = int.Parse(text.text);
        t++;
        text.text = t.ToString();
    }
    public void ReStart()
    {
        SceneManager.LoadScene("GameScene");
    }
    //�����¼�����
    private void EventFouces()
    {
        rb.Onplus += OnClick;//���ĳ��������л��¼�
        rb.Onplus += AnimationChange;//����������������������һ�׶�
        rb.Onplus += birdController.ControlStart;//С��״̬תΪ�˹�����
        birdController.Dead += OnClick; //�������л�

    }

}
