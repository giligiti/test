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
    public GameObject scendobject;//场景二的子物体，用于订阅事件
    public Number rb;//获取scendobject脚本对象
    public GameObject Third;
    Text text;//获得场景三子对象上的Text组件
    public GameObject Fours;

    public GameObject Player;//获得小鸟对象
    private Animator animator;//小鸟动画播放器
    BirdController birdController;//获得小鸟身上的脚本

    
    GameObject Now;//表示当前场景
    GameObject before;//表示前一个场景
    Scene scene;//表示当前场景的编号
    
    private void Awake()
    {
        scene = Scene.four;
        Now = Fours;

        rb = scendobject.GetComponent<Number>();
        
        animator = Player.GetComponentInChildren<Animator>();
        birdController = Player.GetComponentInChildren<BirdController>();
        text = Third.GetComponentInChildren<Text>();
        text.text = "0";
        //订阅各个事件
        EventFouces();

        //先失活
        First.SetActive(true);
        Second.SetActive(false);
        Third.SetActive(false);
        Fours.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator.SetInteger("State", 0);//初始化状态机
        OnClick();
    }

    #region 切换场景
    /// <summary>
    /// 选择场景
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
                Debug.LogWarning("出错了");
                break;
        }
        Space();
    }
    /// <summary>
    /// 按键切换场景
    /// </summary>
    public void OnClick()
    {
        //场景编号往前+1
        scene += 1;

        //超过限制重置
        if (scene > Scene.four)
        {
            scene = Scene.one;
        }
        Select();
        
    }
    
    /// <summary>
    /// 切换场景
    /// </summary>
    /// <param name="n"></param>
    void Space()
    {
        before.SetActive(false);
        Now.SetActive(true);
    }
    #endregion

    #region 动画状态改变

    /// <summary>
    /// 动画状态往前推进
    /// </summary>
    public void AnimationChange()//按下开始游戏键
    {
        int a = animator.GetInteger("State");
        a += 1;
        animator.SetInteger("State", a );
    }


    #endregion
    //得分增加方法
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
    //订阅事件方法
    private void EventFouces()
    {
        rb.Onplus += OnClick;//订阅场景二的切换事件
        rb.Onplus += AnimationChange;//场景二结束，动画进入下一阶段
        rb.Onplus += birdController.ControlStart;//小鸟状态转为人工控制
        birdController.Dead += OnClick; //场景三切换

    }

}
