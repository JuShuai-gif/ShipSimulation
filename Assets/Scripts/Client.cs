using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;
using System.Text;
using System.IO.MemoryMappedFiles;
using System.Threading;
using System.IO;

public class Client : MonoBehaviour
{
    // C# ����ͨ����
    Socket CameraClient;
    // ���ڱ�ʾIP��ַ�Ͷ˿ںŵ����
    public IPEndPoint ipendPoint;

    //�̶�����
    // �����׺��������png�Լ��κκ�׺�������ԣ�ֻҪ�ܳɹ���ȡ����
    const string cameraFileName = "CarCamera.cam";
    const string locFileName = "data";       //���ڲ����ڴ�ط�����ƣ����ֻ�����ļ����֣��������ļ�����
    const string endSymbol = "\t";              //��Ϣ������
    const float pi = 3.1415926f;

    //���в���
    bool connect_flag = false;          //���������ӱ�־λ

    //unity�����ؼ�
    [SerializeField] private RenderTexture target;
    [SerializeField] private Camera CarCamera;
    [SerializeField] private Transform Ladar;
    [SerializeField] private bool UsingLadar_16;
    /* ---------------------------------------------------��ʼ��--------------------------------------------------- */
    // Start is called before the first frame update
    void Start()
    {
        /* ���ÿͻ��˽ӿ� */
        CameraClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        /* ���ӷ����� */
        ConnectToServer();
        ///* �����״��߳� */
        //ThreadStart ladarRef = new ThreadStart(LadarThread);
        //Thread ladarThread = new Thread(ladarRef);
        //ladarThread.Start();
        ///* ��������߳� */
        //ThreadStart CameraRef = new ThreadStart(CameraThread);
        //Thread cameraThread = new Thread(CameraRef);
        //cameraThread.Start();
    }

    /* ---------------------------------------------------���ӷ��������API--------------------------------------------------- */
    // ���ӷ�����
    public void ConnectToServer()
    {
        ipendPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
        Debug.Log("��ʼ���ӷ�����......");
        //�������ӣ�����ȡ����״̬
        CameraClient.BeginConnect(ipendPoint, ConnectCallback, "");
    }

    // ���ӵĻص�
    public void ConnectCallback(IAsyncResult ar)
    {
        try
        {
            CameraClient.EndConnect(ar);
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
        //�жϵ������ӳɹ��˻���û��
        if (CameraClient.Connected == true)
        {
            //�������ӳɹ��Ļص�
            Debug.Log("���ӳɹ�");
            connect_flag = true;
        }
        else
        {
            //����ʧ��
            Debug.Log("����ʧ��");
            connect_flag = false;
        }
    }

    /* ---------------------------------------------------ѭ������--------------------------------------------------- */
    //int not_connect_frame = 0;          //��¼û�����ӵ�֡��
    string loc_filename;                    //���ݱ����ļ���
    void Update()
    {
        /* ����ͼƬ������ */
        OnUserSave(cameraFileName);
        //SaveImageToJPG(30);
        //SaveImageToJPG(50);           //�������ͼƬ(.jpg)
        if (!UsingLadar_16)
        {
            /*--���ʹ�õ����״�--*/
            /* ��ȡ�״����� */
            Vector3 L_point = getLaderPoint();
            /* �������� */
            loc_filename = savelocData(L_point);
        }
        else if (UsingLadar_16)
        {
            /*--���ʹ��16���״�--*/
            /* ��ȡ�״����� */
            Vector3[] L_point = getLaderPoint_16();
            /* �������� */
            loc_filename = savelocData_16(L_point);
        }
        else return;
        /* ����������˷����� */
        if (connect_flag)
        {
            /* ������Ϣ
             * ���ݸ�ʽ��
             *      imageHead:<cameraFileName><endSymbol>loc:<loc_filename><endSymbol>
             */
            /* ���巢����Ϣ */
            string mes = "imageHead:" + cameraFileName + endSymbol;       //ͼƬ�ļ�������Ϣ
            mes += "locHead:" + loc_filename + endSymbol;                     //λ����Ϣ������Ϣ
            /* ������Ϣ */
            try
            {
                PutMessageToQueue(mes);
            }
            catch (SocketException e)
            {
                /* ������ʹ�����Ͽ����� */
                Debug.Log("�Ͽ��������������");
                connect_flag = false;
            }
        }
        else
        {
            /* ���û�����ӷ��������򲻶��������� */
            //not_connect_frame++;
            //if (not_connect_frame >= 200) {
            //    CameraClient.BeginConnect(ipendPoint, ConnectCallback, "");
            //    Debug.Log("�����������ӷ�����......");
            //    not_connect_frame = 0;
            //}

        }
    }

    /* ---------------------------------------------------���߳�ѭ������--------------------------------------------------- */
    /* �״����ݻ�ȡ�߳� */
    public void LadarThread()
    {
        while (true)
        {
            /* ��ȡ�״����� */
            //Vector3 point = getLaderPoint();
        }
    }

    /* ����߳� */
    public void CameraThread()
    {
        while (true)
        {

        }
    }

    /* ---------------------------------------------------��������Ϣ����API--------------------------------------------------- */
    /// <summary>
    /// ������Ϣ�Ļص�
    /// </summary>
    /// <param name="ar"></param>
    public void SendMessageCallback(IAsyncResult ar)
    {
        //ֹͣ����
        int length = CameraClient.EndSend(ar);
        //Debug.Log("���͵ĳ��ȣ�" + length);
    }

    /// <summary>
    /// ������Ϣ��������
    /// </summary>
    /// <param name="sendMsgContent"></param>
    /// <param name="offset"></param>
    /// <param name="size"></param>
    public void SendBytesMessageToServer(byte[] sendMsgContent, int offset, int size)
    {
        CameraClient.BeginSend(sendMsgContent, offset, size, SocketFlags.None, SendMessageCallback, "");
    }

    /// <summary>
    /// ������Ϣ������
    /// </summary>
    /// <param name="msg"></param>
    public void PutMessageToQueue(string msg)
    {
        //���������л�����ȥ
        byte[] msgBytes = ASCIIEncoding.UTF8.GetBytes(msg);
        SendBytesMessageToServer(msgBytes, 0, msgBytes.Length);
    }


    /* ---------------------------------------------------ͼ�񱣴����API--------------------------------------------------- */
    int frame = 0, image_index = 0;
    public void SaveImageToJPG(int fcount)
    {
        frame++;
        if (frame >= fcount)
        {
            /* ��ȡ�����ļ�·�� */
            string filename = image_index + string.Format(".jpg");
            var prePath = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf("/"));
            string path = prePath + string.Format("/Assets/image/Save/") + filename;
            Debug.Log(path);
            /* ��ȡ�����ļ����� */
            Texture2D texture2D = CreateFrom(target);
            var bytes = texture2D.EncodeToJPG();
            System.IO.File.WriteAllBytes(path, bytes);
            /* ֡���Լ�������ͼƬ�����޸� */
            frame = 0;
            image_index++;
        }

    }

    public void OnUserSave(string filename)
    {
        var prePath = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf("/"));
        string path = prePath + string.Format("/Assets/__buffer__/") + filename;
        try
        {
            Save(path, CreateFrom(target));
        }
        catch (IOException e)
        {

        }

    }

    public void Save(string path, Texture2D texture2D)
    {
        var bytes = texture2D.EncodeToPNG();
        //var bytes = texture2D.EncodeToJPG();
        System.IO.File.WriteAllBytes(path, bytes);
    }

    // RTתTexture2D
    public Texture2D CreateFrom(RenderTexture renderTexture)
    {
        Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
        var previous = RenderTexture.active;
        RenderTexture.active = renderTexture;

        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);

        RenderTexture.active = previous;

        texture2D.Apply();

        return texture2D;
    }

    /* ---------------------------------------------------�״����API--------------------------------------------------- */
    const int maxDis = 100;         // max distance���״��������
    // �����״�
    public Vector3 getLaderPoint()
    {
        /* ��ȡ�״�� */
        Ladar.Rotate(new Vector3(0, 3.1f / 60.0f, 0));         //�״���ת
        Ray ray = new Ray(Ladar.position, Ladar.forward * maxDis);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDis))
        {
            /* ����״���������ײ */
            Debug.DrawLine(Ladar.position, hit.point, Color.red);
            return hit.point;
        }

        Debug.DrawLine(Ladar.position, Ladar.position + Ladar.forward * maxDis, Color.red);
        // �������ֵ��(0,0,0)�Ļ���˵��û����ײ����
        return new Vector3(0, 0, 0);
    }

    /// <summary>
    /// ʮ�����״�
    /// </summary>
    /// <returns></returns>
    public Vector3[] getLaderPoint_16()
    {
        /* ��ȡ�״�� */
        Ladar.Rotate(new Vector3(0, 3.1f / 60.0f, 0)*30000);         //�״���ת
        Vector3[] res = new Vector3[16];        //��ά���������飬���ڴ洢�״���Ϣ
        const float angle_max = 8;         //�״����Ƕ�

        for (int i = 0; i < 8; i++)
        {
            /* �״�������ת */
            Vector3 dir_up = Vector3Rotate(Ladar.forward, Vector3.left, angle_max / 8.0f * i);          //ȷ���״﷽��
            Ray ray_up = new Ray(Ladar.position, dir_up * maxDis);              //�����״�����
            RaycastHit hit_up;          //����������ײ��
            if (Physics.Raycast(ray_up, out hit_up, maxDis))
            {
                /* ����״���������ײ */
                Debug.DrawLine(Ladar.position, hit_up.point, Color.blue);
                res[i * 2] = hit_up.point;
            }
            else
                Debug.DrawLine(Ladar.position, Ladar.position + dir_up * maxDis, Color.blue);
            /* �״�������ת */
            Vector3 dir_down = Vector3Rotate(Ladar.forward, Vector3.left, -angle_max / 8.0f * i);        //ȷ���״﷽��
            Ray ray_down = new Ray(Ladar.position, dir_down * maxDis);          //�����״�����
            RaycastHit hit_down;            //����������ײ��
            if (Physics.Raycast(ray_down, out hit_down, maxDis))
            {
                /* ����״���������ײ */
                Debug.DrawLine(Ladar.position, hit_down.point, Color.blue);
                res[i * 2 + 1] = hit_down.point;
            }
            else
                Debug.DrawLine(Ladar.position, Ladar.position + dir_down * maxDis, Color.blue);
        }

        return res;
    }

    int index = 0;
    public string savelocData(Vector3 p)
    {
        /* 
         * �������ָ���ļ� 
         * �����ڴ����ƣ��ڴ�ط�Ϊ10������index��ֵΪ��0-10
         * ����д�벿�ֺ͵��ò��ֿ��Էֿ�
         * ���ر����ļ���
         */
        const string file_type = ".loc";        //�ļ���׺
        var prePath = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf("/"));         //��ȡ��ǰ����·��
        string path = prePath + "/Assets/__buffer__/__loc__/" + locFileName + index + file_type;        //�洢�ļ�·��
        /* ����ļ������ڣ��򴴽��ļ� */
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
        }
        /* ��ȡ�ļ�ָ�� */
        FileInfo f = new FileInfo(path);
        /* ���������������±༭�ļ� */
        StreamWriter sw = f.CreateText();
        /* ���浱ǰ������ */
        Transform ladar_t = Ladar;
        sw.WriteLine(string.Format("{0:F2},", ladar_t.position[0]) + string.Format("{0:F2},", ladar_t.position[1]) + string.Format("{0:F2}", ladar_t.position[2]));
        /* �����״����� */
        sw.WriteLine(string.Format("{0:F2},", p[0]) + string.Format("{0:F2},", p[1]) + string.Format("{0:F2}", p[2]));
        sw.Close();

        index++;
        index = index < 10 ? index : 0;
        return locFileName + index + file_type;
    }


    public string savelocData_16(Vector3[] p)
    {
        /* 
         * ������savelocDataһ�£�ֻ�����������16���״�
         */
        const string file_type = ".loc";            //�ļ���׺
        var prePath = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf("/"));         //��ȡ��ǰ������Ϣ
        string path = prePath + "/Assets/__buffer__/__loc16__/" + locFileName + index + file_type;      //�洢�ļ�·��
        /* ����ļ������ڣ��򴴽��ļ� */
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
        }
        /* ��ȡ�ļ�ָ�� */
        FileInfo f = new FileInfo(path);
        /* ���������������±༭�ļ� */
        StreamWriter sw = f.CreateText();
        /* ���浱ǰ������ */
        Transform ladar_t = Ladar;
        sw.WriteLine(string.Format("{0:F2},", ladar_t.position[0]) + string.Format("{0:F2},", ladar_t.position[1]) + string.Format("{0:F2}", ladar_t.position[2]));
        /* ����16���״����� */
        for (int i = 0; i < 16; i++)
        {
            sw.WriteLine(string.Format("{0:F2},", p[i][0]) + string.Format("{0:F2},", p[i][1]) + string.Format("{0:F2}", p[i][2]));
        }
        sw.Close();

        index++;
        index = index < 10 ? index : 0;
        return locFileName + index + file_type;
    }

    /* ---------------------------------------------------�����ڴ����API--------------------------------------------------- */
    void MyMmp(string str)
    {
        //// ����
        //long t = 100;
        //// �����ڴ�飬test1,����������������ڴ�����־����ҵ��ڴ�顣
        //var mmf = MemoryMappedFile.CreateOrOpen("CarCamera", t, MemoryMappedFileAccess.ReadWrite);
        //var viewAccessor = mmf.CreateViewAccessor(0, t);
        //viewAccessor.Write(0, str.Length); ;
        //viewAccessor.WriteArray<byte>(0, System.Text.Encoding.Default.GetBytes(str), 0, str.Length);
        int size = 1024;
        MemoryMappedFile shareMemory = MemoryMappedFile.CreateOrOpen("CarCamera", size);
        var stream = shareMemory.CreateViewStream(0, size);
        byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
        stream.Write(data, 0, data.Length);
        stream.Dispose();
    }


    /* ---------------------------------------------------���ߺ���--------------------------------------------------- */
    /// <summary>
    /// Χ��ĳ����תָ���Ƕ�
    /// </summary>
    /// <param name="vector">��ת����</param>
    /// <param name="axis">Χ����ת��</param>
    /// <param name="angle">��ת�Ƕ�</param>
    /// <returns></returns>
    public Vector3 Vector3Rotate(Vector3 vector, Vector3 axis, float angle)
    {
        return Quaternion.AngleAxis(angle, axis) * vector;
    }
}
