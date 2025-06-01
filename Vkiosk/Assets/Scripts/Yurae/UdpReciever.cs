// Unity
using UnityEngine;

// System
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Generic;

// Newton
using Newtonsoft.Json.Linq;

[DisallowMultipleComponent]
public class UdpReceiver : MonoBehaviour
{
    [SerializeField] private GestureManager gestureManager;

    private UdpClient udpClient;
    private Thread thread;
    private Queue<(string, Vector3)> gestureQueue = new Queue<(string, Vector3)>();

    void Start()
    {
        // Init host port
        udpClient = new UdpClient(5055);

        // Init thread
        thread = new Thread(ReceiveData);
        thread.IsBackground = true;
        thread.Start();
    }

    /// <summary>
    /// To Receive Data
    /// </summary>
    void ReceiveData()
    {
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 5055);

        while (true)
        {
            try
            {
                // Get Data
                byte[] data = udpClient.Receive(ref endPoint);

                // Get String
                string json = Encoding.UTF8.GetString(data);

                // Parsing
                JObject parsed = JObject.Parse(json);

                // Get Json
                string gesture = parsed["gesture"].ToString();
                float x = (float)parsed["position"]["x"];
                float y = (float)parsed["position"]["y"];
                float z = (float)parsed["position"]["z"];

                lock (gestureQueue)
                {
                    gestureQueue.Enqueue((gesture, new Vector3(x, y, z)));
                }
            }
            catch (System.Exception e)
            {
                Debug.LogWarning("UDP Receive Error: " + e.Message);
            }
        }
    }

    void Update()
    {
        GetAndSendGestrue();
    }

    private void GetAndSendGestrue()
    {
        lock (gestureQueue)
        {
            while (gestureQueue.Count > 0)
            {
                Debug.Log("Update Tick");
                var (gesture, handPos) = gestureQueue.Dequeue();
                gestureManager.UpdateGestureFromNetwork(gesture, handPos);
            }
        }
    }

    void OnApplicationQuit()
    {
        udpClient?.Close();
        thread?.Abort();
    }
}
