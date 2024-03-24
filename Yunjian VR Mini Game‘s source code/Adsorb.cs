using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Adsorb : MonoBehaviour
{
    public string Tags;
    public bool state;
    private void OnTriggerEnter(Collider other)
    {
        XRGrabInteractable xb = other.GetComponent<XRGrabInteractable>();
        Debug.Log(other.tag);
        if (xb != null && Tags==xb.gameObject.tag) 
        {
            if (xb.isSelected)
            {
                // 获取当前抓取这个物体的交互者
                var v = xb.firstInteractorSelecting;
                xb.interactionManager.SelectExit(v,xb);
                // 强制交互者释放物体
                state = true;
                xb.enabled = false;
            }
            xb.transform.parent= this.transform;
            xb.transform.localPosition = Vector3.zero;
            xb.transform.localRotation = Quaternion.identity;
        }
       
    }
}
