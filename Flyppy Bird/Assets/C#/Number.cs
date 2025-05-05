using System;
using UnityEngine;
using UnityEngine.UI;
//ʵ�ֳ�������
public class Number : MonoBehaviour
{
    public Sprite[] Sprites;
    public float time;//ÿ������ʱ������ʾ��ʱ��
    private Image Picture;
    private Animator animator;
    int num = 0;//ͼƬ����

    public event Action Onplus;//�����¼�,��ʾ�л�����
    private void Awake()
    {
        Picture = GetComponent<Image>();
        animator = GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //���������ٶȵ���
        AnimationSpeed();

        //ͼƬ��ʼ��
        PictureChange();
    }
    /// <summary>
    /// ����������Ϻ󴥷��¼�
    /// </summary>
    public void OnAnimationEnd()
    {
        num++;
        if (num == Sprites.Length)
        {
            num = 0;
            Onplus();
        }
        else
        {
            PictureChange();
        }
        
    }
    private void PictureChange()
    {
        Picture.sprite = Sprites[num];
    }
    //���������ٶ�
    void AnimationSpeed()
    {
        if(animator.runtimeAnimatorController != null)
        {
            AnimationClip animi = null;
            foreach(var item in animator.runtimeAnimatorController.animationClips)
            {
                if (item.name == "Number")
                {
                    animi = item;
                    break;
                }
            }
            float orginspeed = animi.length;
            animator.speed = orginspeed / time;
        }
    }
}
