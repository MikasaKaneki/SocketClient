using System;
using System.Net.Sockets;
using Share;
using UnityEngine;

/// <summary>
/// 用来管理和服务器端的Socket连接
/// </summary>
public class ClientManager : BaseManager
{
    private const string IP = "127.0.0.1";
    private const int port = 8090;
    private Socket _clientSocket;

    public override void OnInit()
    {
        base.OnInit();
        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            _clientSocket.Connect(IP, port);
        }
        catch (Exception e)
        {
            Debug.LogWarning("ClientSockegt无法连接到服务器 " + e.Message);
        }
    }


    public void SendRequest(RequestCode requestCode, ActionCode actionCode, string data)
    {

    }

    public override void OnDesory()
    {
        base.OnDesory();
        try
        {
            _clientSocket.Close();
        }
        catch (Exception e)
        {
            Debug.LogWarning("无法关闭和客户端的连接" + e.Message);
        }
    }
}