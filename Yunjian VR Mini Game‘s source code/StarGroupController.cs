using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class StarGroupController : MonoBehaviour
{
    public Paper_Cut paperCutScript; // 参考Paper_Cut脚本
    private Animator animator; // Animator组件
    private bool hasBeenCut = false; // 标记是否已剪切

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the object.");
        }
        // 初始时隐藏Star Group对象
        gameObject.SetActive(false);
    }

    void Update()
    {
        // 检查是否剪切并且之前未处理
        if (paperCutScript.isCut && !hasBeenCut)
        {
            hasBeenCut = true; // 更新已处理标记
            gameObject.SetActive(true); // 显示Star Group对象
            PlayAnimation(); // 播放动画
        }
    }

    void PlayAnimation()
    {
        if (animator != null)
        {
            animator.Play("StarGroup Animation");
        }
    }
}