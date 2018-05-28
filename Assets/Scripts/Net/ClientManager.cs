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
    private Message msg;


    public ClientManager(GameFacade facade) : base(facade)
    {
    }

    public override void OnInit()
    {
        base.OnInit();
        msg = new Message();
        _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            _clientSocket.Connect(IP, port);
            Start();
        }
        catch (Exception e)
        {
            Debug.LogError("ClientSockegt无法连接到服务器 " + e.Message);
        }
    }


    private void Start()
    {
        _clientSocket.BeginReceive(msg.Data, msg.CurDataSize, msg.RemianSize, SocketFlags.None, ReceiveCallback, null);
    }

    private void ReceiveCallback(IAsyncResult ar)
    {
        try
        {
            int count = _clientSocket.EndReceive(ar);
            msg.ReadMessage(count, OnProcessDataCallback);
            Start();
        }
        catch (Exception ex)
        {
            Debug.LogError("ReceiveCallback is error:" + ex.Message);
        }
    }


    private void OnProcessDataCallback(ActionCode actionCode, string data)
    {
        _facade.HandleReponse(actionCode, data);
    }

    public void SendRequest(RequestCode requestCode, ActionCode actionCode, string data)
    {
        Debug.Log("{Client} Send to Server data is:" + data);
        byte[] bytes = Message.PackData(requestCode, actionCode, data);
        _clientSocket.Send(bytes);
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