using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class StarGroupController : MonoBehaviour
{
    public Paper_Cut paperCutScript; // �ο�Paper_Cut�ű�
    private Animator animator; // Animator���
    private bool hasBeenCut = false; // ����Ƿ��Ѽ���

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the object.");
        }
        // ��ʼʱ����Star Group����
        gameObject.SetActive(false);
    }

    void Update()
    {
        // ����Ƿ���в���֮ǰδ����
        if (paperCutScript.isCut && !hasBeenCut)
        {
            hasBeenCut = true; // �����Ѵ�����
            gameObject.SetActive(true); // ��ʾStar Group����
            PlayAnimation(); // ���Ŷ���
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