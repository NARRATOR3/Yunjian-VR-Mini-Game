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
                // ��ȡ��ǰץȡ�������Ľ�����
                var v = xb.firstInteractorSelecting;
                xb.interactionManager.SelectExit(v,xb);
                // ǿ�ƽ������ͷ�����
                state = true;
                xb.enabled = false;
            }
            xb.transform.parent= this.transform;
            xb.transform.localPosition = Vector3.zero;
            xb.transform.localRotation = Quaternion.identity;
        }
       
    }
}
