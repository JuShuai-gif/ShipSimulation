using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveContral : MonoBehaviour
{
    public float speed = 5f; // 控制移动的速度

    void Update()
    {
        // 获取水平输入（左右箭头键、A和D键或手柄左摇杆水平输入）
        float horizontalInput = Input.GetAxis("Horizontal");

        // 获取垂直输入（上下箭头键、W和S键或手柄左摇杆垂直输入）
        float verticalInput = Input.GetAxis("Vertical");

        // 计算移动方向
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // 将移动方向转换为世界坐标
        movement = transform.TransformDirection(movement);

        // 根据速度乘以时间来移动物体
        transform.position += movement * speed * Time.deltaTime;
    }
}
