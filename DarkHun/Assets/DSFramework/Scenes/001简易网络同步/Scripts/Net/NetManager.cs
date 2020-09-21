using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Sockets;
using UnityEngine;

public static class NetManager {
    static Socket socket;

    /// <summary>
    /// 接收缓冲区
    /// </summary>
    static byte[] readBuff = new byte[1024];

    /// <summary>
    /// 监听消息委托
    /// </summary>
    /// <param name="msg"></param>
    public delegate void MsgListener(string msg);

    /// <summary>
    /// 监听列表
    /// </summary>
    private static Dictionary<string, MsgListener> listeners = new Dictionary<string, MsgListener>();

    /// <summary>
    /// 消息列表
    /// </summary>
    static List<string> MsgList = new List<string>();

    /// <summary>
    /// 添加监听
    /// </summary>
    /// <param name="msgName"></param>
    /// <param name="msgListener"></param>
    public static void AddListener(string msgName, MsgListener msgListener) {
        listeners[msgName] = msgListener;
    }

    /// <summary>
    /// 获取描述(IP和端口)
    /// </summary>
    /// <returns></returns>
    public static string GetDesc() {
        if (socket == null) return "";
        if (!socket.Connected) return "";
        return socket.LocalEndPoint.ToString();
    }

     public static void Connect(string ip,int port) {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.Connect(ip, port);
        socket.BeginReceive(readBuff, 0, 1024, 0, ReceiveCallback, socket);
    }

    private static void ReceiveCallback(IAsyncResult ar) {
        try {
            Socket socket = (Socket)ar.AsyncState;
            int count = socket.EndReceive(ar);
            string recvStr = System.Text.Encoding.UTF8.GetString(readBuff, 0, count);
            MsgList.Add(recvStr);
            socket.BeginReceive(readBuff, 0, 1024, 0, ReceiveCallback, socket);
        } catch (SocketException se) {

            Debug.Log("socket Receive fail" + se.ToString());
        }
    }

    public static void Send(string sendStr) {
        if (socket == null) return;
        if (!socket.Connected) return;

        byte[] sendBytes = System.Text.Encoding.UTF8.GetBytes(sendStr);
        socket.Send(sendBytes);
    }

    public static void Update() {
        if (MsgList.Count <= 0) return;

        string msgStr = MsgList[0];
        MsgList.RemoveAt(0);
        string[] split = msgStr.Split('|');
        string msgName = split[0];
        string msgArgs= split[1];

        if (listeners.ContainsKey(msgName)) {
            listeners[msgName](msgArgs);
        }
    }
}
