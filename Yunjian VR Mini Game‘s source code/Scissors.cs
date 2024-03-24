using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : MonoBehaviour
{

    public int count;
    public UnityEngine.Events.UnityEvent callback;
    public void CountEvent(int countPar)
    {
        count++;

        if (count >= countPar) callback?.Invoke();//把纸掉落的函数放到这个事件里
    }
   
    public Paper_Cut p;
    public void Cut()
    {
        p.BeCut();
    }
    public float opentime = 1;
    public float closetime = 1;
    public Vector3 s1ToRot;
    public Vector3 s2ToRot;
    void AniRun(float p)
    {
        transform.Find("1").localRotation = Quaternion.Lerp(Quaternion.identity,Quaternion.Euler(s1ToRot),p);
        transform.Find("2").localRotation = Quaternion.Lerp(Quaternion.identity,Quaternion.Euler(s2ToRot),p);
    }
    IEnumerator IEAniRun(float form,float to,float time)
    {
        aniRunFlag = true;
        float timing = 0;
        while (timing<time)
        {
            timing += Time.deltaTime;
            AniRun(Mathf.Lerp(form, to, timing/time));
            yield return null;
        }
        aniRunFlag = false;
    }
    public bool aniRunFlag = false;
    public IEnumerator IEOnOff(float timeon, float timeoff)
    {
      
        yield return IEAniRun(0, 1, timeon);
        yield return IEAniRun(1, 0, timeoff);
       
    }
    public void StartAniRun()
    {
        Debug.Log("StartAniRun");
        if (aniRunFlag == false)
        {
            StartCoroutine(IEOnOff(opentime, closetime));
        }
        else
        {
            Debug.Log("动画运行中");
        }
    }
}
