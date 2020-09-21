using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NetMain : MonoBehaviour {

    public GameObject humanPrefab;

    private BaseHuman myHuman;

    public Dictionary<string, BaseHuman> otherHuman = new Dictionary<string, BaseHuman>();

    void Start() {
        NetManager.AddListener("Enter", OnEnter);
        NetManager.AddListener("Move", OnMove);
        NetManager.AddListener("Leave", OnLeave);
        NetManager.Connect("127.0.0.1", 8888);


        GameObject obj = (GameObject)Instantiate(humanPrefab);
        float x = Random.Range(-5, 5);
        float z = Random.Range(-5, 5);
        obj.transform.position = new Vector3(x, 0f, z);
        myHuman = obj.AddComponent<CtrlHuman>();
        myHuman.desc = NetManager.GetDesc();

        //发送协议
        Vector3 pos = myHuman.transform.position;
        Vector3 eul = myHuman.transform.eulerAngles;
        string sendStr = "Enter|";
        sendStr += NetManager.GetDesc() + ",";
        sendStr += pos.x + ",";
        sendStr += pos.y + ",";
        sendStr += pos.z + ",";
        sendStr += eul.y + "";
        NetManager.Send(sendStr);
    }

    private void Update() {
        NetManager.Update();
    }

    private void OnEnter(string msg) {
        Debug.Log("OnEnter" + msg);

        //解析参数
        string[] split = msg.Split(',');
        string desc = split[0];
        float x = float.Parse(split[1]);
        float y = float.Parse(split[2]);
        float z = float.Parse(split[3]);
        float eulY = float.Parse(split[4]);

        //如果是自己则返回
        if (desc.Equals(NetManager.GetDesc())) return;

        GameObject obj = Instantiate(humanPrefab);
        obj.transform.position = new Vector3(x, y, z);
        obj.transform.eulerAngles = new Vector3(0, eulY, 0);
        BaseHuman h = obj.AddComponent<SyncHuman>();
        h.desc = desc;
        otherHuman.Add(desc, h);

    }

    private void OnMove(string msg) {
        Debug.Log("OnMove" + msg);
    }

    private void OnLeave(string msg) {
        Debug.Log("OnLeave" + msg);
    }

}
