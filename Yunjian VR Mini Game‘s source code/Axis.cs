using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Axis : MonoBehaviour
{
    public Transform setobj;
    public Transform oripoint;
    public int dir=-1;


    private Quaternion lastRotation;
    private float totalRotation = 0f;
    public UnityEngine.Events.UnityEvent unityEvent;
    void Start()
    {
        // ��ʼ����һ�ε���תΪ���嵱ǰ����ת
        lastRotation =setobj. transform.rotation;
    }
    private void Update()
    {
        // setobj.up = (setobj.position - transform.position) .normalized* dir;
        setobj.up = Vector3.ProjectOnPlane((setobj.position - transform.position).normalized * dir, setobj.transform.forward);
        UpdateP();
    }
    void UpdateP()
    {
        // �������ϴθ�������������ת�˶��ٶ�
        float rotationDelta = Quaternion.Angle(lastRotation, setobj. transform.rotation);

        // ��������ת����
        totalRotation += rotationDelta;

        // �������ת��������360�ȣ���ʾ��������ת��һ��
        if (totalRotation >= 360f)
        {
            Debug.Log("�����Ѿ�ת������һ��");
            // ��������ת�������Ա��ٴθ���
            unityEvent?.Invoke();
           totalRotation -= 360f;
        }

        // ������һ�ε���תΪ��ǰ��ת
        lastRotation = setobj.transform.rotation;
    }

    public void ResetPos()
    {
        transform.position = oripoint.position;
    }
}
