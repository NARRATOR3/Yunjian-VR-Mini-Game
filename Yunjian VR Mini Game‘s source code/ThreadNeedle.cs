using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Transformers;
using static UnityEngine.XR.Interaction.Toolkit.Transformers.XRGeneralGrabTransformer;

public class ThreadNeedle : MonoBehaviour
{
    public string tags;
    public GameObject prefabs;
    int count;
    public UnityEngine.Events.UnityEvent unityEvent;
    public MeshRenderer probar;
    public XRGeneralGrabTransformer xRGeneralGrabTransformer;

    private void OnEnable()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tags) 
        {
            GameObject g=   Instantiate(prefabs); 
            g. transform.position=other.ClosestPoint(transform.position);
            g.transform.parent= other.transform;
            count++;
            if (count >= 10) 
            {
                unityEvent?.Invoke();
                xRGeneralGrabTransformer.permittedDisplacementAxes = ManipulationAxes.All;
            } 
            float x=  probar.material.GetFloat("_Fill");
            probar.material.SetFloat("_Fill", x+0.1f);
        }
    }
}
