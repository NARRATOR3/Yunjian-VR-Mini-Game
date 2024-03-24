using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsorbManager : MonoBehaviour
{
    public Adsorb[] adsorbs;
    public UnityEngine.Events.UnityEvent unityEvent;
    private void Update()
    {
        if (State())
        {
            unityEvent?.Invoke();
        }
    }


    bool State()
    {
        bool s =true;
        for (int i=0;i<adsorbs.Length;i++)
        {
            if (!adsorbs[i].state)
                s = false;
        }

        return s; 
    }
}
