using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioStationPage106 : MonoBehaviour
{
    public Toggle kaiguan;


    public ButtonBase close;

    private void Awake()
    {
        kaiguan.onValueChanged.AddListener(OnKaiGuanValueChanged);

        close.RegistClick(OnClickClose);
    }

    private void OnClickClose(GameObject obj)
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 开关
    /// </summary>
    private void OnKaiGuanValueChanged(bool value)
    {
        RadioStationOp106Model opModel = new RadioStationOp106Model()
        {
            Operate = value ? 1 : 0,
            Type = RadioStationOpType106.OpenClose,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.RadioStation_OP_106);
    }
}
