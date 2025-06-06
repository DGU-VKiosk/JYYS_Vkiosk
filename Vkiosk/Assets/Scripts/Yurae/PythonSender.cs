using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class PythonSender : MonoBehaviour
{
    UdpClient udpClient;
    string pythonIP = "127.0.0.1"; // ���� ��ǻ���� ��� localhost
    int pythonPort = 5056;         // Python ���� ��Ʈ

    void Start()
    {
        udpClient = new UdpClient();
    }

    public void SendMessageToPython(string _message)
    {
        byte[] data = Encoding.UTF8.GetBytes(_message);
        udpClient.Send(data, data.Length, pythonIP, pythonPort);
        Debug.Log("Sent to Python: " + _message);
    }
}
