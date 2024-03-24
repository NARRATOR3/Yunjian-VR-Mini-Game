using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Paper_Cut : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (sciEnter == false)
        {
            if (timing > 0)
            {
                timing -= Time.deltaTime;
            }
        }
    }
    public bool sciEnter = false;
    public float triggerTime = 1.5f;
    private float timing = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Scissors>() != null)
        {
            sciEnter = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Scissors>() != null)
        {
            sciEnter = true;
            timing += Time.deltaTime;
            if (timing >= triggerTime)
            {
                if (!isCut)
                {
                    // Cut();
                }

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Scissors>() != null)
        {
            sciEnter = false;
        }
    }
    public bool isCut = false;
    public void BeCut()
    {
        Debug.Log(isCut);
        isCut = true;
        transform.Find("Fall").GetComponent<Cloth>().enabled = true;

    }

}

