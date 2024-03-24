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
        // 初始化上一次的旋转为物体当前的旋转
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
        // 计算自上次更新以来物体旋转了多少度
        float rotationDelta = Quaternion.Angle(lastRotation, setobj. transform.rotation);

        // 更新总旋转度数
        totalRotation += rotationDelta;

        // 如果总旋转度数超过360度，表示物体至少转了一周
        if (totalRotation >= 360f)
        {
            Debug.Log("物体已经转了至少一周");
            // 重置总旋转度数，以便再次跟踪
            unityEvent?.Invoke();
           totalRotation -= 360f;
        }

        // 更新上一次的旋转为当前旋转
        lastRotation = setobj.transform.rotation;
    }

    public void ResetPos()
    {
        transform.position = oripoint.position;
    }
}
