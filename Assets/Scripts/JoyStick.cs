using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
 
public class JoyStick : MonoBehaviour
{
    
    public Transform Stick;
    public Transform Player;
    public Vector3 JoyVec;

    private Vector3 StickFirstPos; 
    private float Radius;
    private bool MoveFlag;


    void Start()
    {
        Radius = GetComponent<RectTransform>().sizeDelta.y * 0.5f;
        StickFirstPos = Stick.transform.position;

        
        float Can = transform.parent.GetComponent<RectTransform>().localScale.x;
        Radius *= Can;
        MoveFlag = false;
    }

    public void Drag(BaseEventData _Data)
    {
        PointerEventData Data = _Data as PointerEventData;
        Vector3 Pos = Data.position;

        
        JoyVec = (Pos - StickFirstPos).normalized;

        
        float Dis = Vector3.Distance(Pos, StickFirstPos);

        
        if (Dis < Radius)
            Stick.position = StickFirstPos + JoyVec * Dis;
        
        else
            Stick.position = StickFirstPos + JoyVec * Radius;
    }

    
    public void DragEnd()
    {
        Stick.position = StickFirstPos; 
        JoyVec = Vector3.zero;
        MoveFlag = false;
    }
}

