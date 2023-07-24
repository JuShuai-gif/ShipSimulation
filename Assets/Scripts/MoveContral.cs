using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveContral : MonoBehaviour
{
    public float speed = 5f; // �����ƶ����ٶ�

    void Update()
    {
        // ��ȡˮƽ���루���Ҽ�ͷ����A��D�����ֱ���ҡ��ˮƽ���룩
        float horizontalInput = Input.GetAxis("Horizontal");

        // ��ȡ��ֱ���루���¼�ͷ����W��S�����ֱ���ҡ�˴�ֱ���룩
        float verticalInput = Input.GetAxis("Vertical");

        // �����ƶ�����
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // ���ƶ�����ת��Ϊ��������
        movement = transform.TransformDirection(movement);

        // �����ٶȳ���ʱ�����ƶ�����
        transform.position += movement * speed * Time.deltaTime;
    }
}
