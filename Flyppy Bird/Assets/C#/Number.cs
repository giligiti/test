using System;
using UnityEngine;
using UnityEngine.UI;
//实现场景二的
public class Number : MonoBehaviour
{
    public Sprite[] Sprites;
    public float time;//每个倒计时数字显示的时长
    private Image Picture;
    private Animator animator;
    int num = 0;//图片索引

    public event Action Onplus;//发布事件,表示切换场景
    private void Awake()
    {
        Picture = GetComponent<Image>();
        animator = GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //动画播放速度调整
        AnimationSpeed();

        //图片初始化
        PictureChange();
    }
    /// <summary>
    /// 动画播放完毕后触发事件
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
    //动画播放速度
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
