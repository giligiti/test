using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinallyPanel : MonoBehaviour
{
    public Text Text;
    public TextMeshProUGUI Finally;//������
    public TextMeshProUGUI BestScroe;//��ʷ���
    public GameObject New;
    public Image Gloden;//����ͼƬ���
    public Sprite[] sprites;//����ͼƬ
    public int GlodenPan;//���ƽ���


    private void OnEnable()
    {
        New.SetActive(false);
        CompereScroe();
        CorrectGloden();
        Save();
    }
    //�ȽϷ���
    private void CompereScroe()
    {
        Finally.text=Text.text;//������
        int a = int.Parse(Finally.text);
        int b = PlayerPrefs.GetInt("best",0);
        BestScroe.text = b.ToString();
        if (a > b)
        {
            //Debug.Log(b);
            BestScroe.text = a.ToString();
            PlayerPrefs.SetInt("best", a);
            Debug.Log(PlayerPrefs.GetInt("best"));
            New.SetActive(true);
        }
    }
    //���ֽ���
    void CorrectGloden()
    {
        int x = int.Parse(Finally.text);
        int a = 0;
        switch (x)
        {
            case int n when(n<=GlodenPan/4):
                a = 0;
                break;
            case int n when (n > GlodenPan / 4 && n <= GlodenPan / 2):
                a = 1;
                break;
            case int n when (n > GlodenPan / 2 && n <= GlodenPan / 4 * 3):
                a = 2;
                break;
            case int n when (n > GlodenPan / 4 * 3 ):
                a = 3;
                break;
        }
        Gloden.sprite = sprites[a];
    }
    void Save()
    {
        PlayerPrefs.Save();
    }
}
