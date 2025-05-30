using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json.Linq;

public class UdpReceiver : MonoBehaviour
{
    UdpClient udpClient;
    Thread thread;

    void Start()
    {
        udpClient = new UdpClient(5055);
        thread = new Thread(new ThreadStart(ReceiveData));
        thread.IsBackground = true;
        thread.Start();
    }

    void ReceiveData()
    {
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 5055);

        while (true)
        {
            try
            {
                byte[] data = udpClient.Receive(ref endPoint);
                string json = Encoding.UTF8.GetString(data);
                JObject parsed = JObject.Parse(json);

                string gesture = parsed["gesture"].ToString();
                float x = (float)parsed["position"]["x"];
                float y = (float)parsed["position"]["y"];
                float z = (float)parsed["position"]["z"];

                UpdateGestureFromNetwork(gesture, new Vector3(x, y, z));
            }
            catch { }
        }
    }

    public void UpdateGestureFromNetwork(string gesture, Vector3 pos)
    {
        switch (gesture)
        {
            case "click": Debug.Log("Click!"); break;
        }
    }

    void OnApplicationQuit()
    {
        udpClient?.Close();
        thread?.Abort();
    }
}
