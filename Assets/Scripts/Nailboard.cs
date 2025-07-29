using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nailboard : MonoBehaviour
{
 public float moveSpeed = 2f;  // NailBoard 移动速度
    public float moveDistance = 5f;  // NailBoard 移动距离

    private Vector3 startPosition;  // NailBoard 的初始位置
    private Vector3 targetPosition;  // NailBoard 的目标位置
    private bool movingUp = false;  // 是否开始移动
     private bool isMoving = false;

    void Start()
    {
        startPosition = transform.position;

        targetPosition = startPosition + new Vector3(0, moveDistance, 0);
        movingUp = false;  // 初始不移动
        isMoving = false;  // 初始时不移动

    }

    void Update()
    {
         if (isMoving)
        {

          if (movingUp)
        {

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
   
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                movingUp = false; 
                targetPosition = startPosition; 
            }
        }
        else
        {

            transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, startPosition) < 0.1f)
            {
                movingUp = true; 
                targetPosition = startPosition + new Vector3(0,moveDistance,0); 
            }
        }
        
    }
    }

    // 外部触发的函数，当按钮被按下时调用
    public void TriggerMovement()
    {
       isMoving = true; 
    }
}
