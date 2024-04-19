using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RadioStationPage : MonoBehaviour
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
        RadioStationOpModel opModel = new RadioStationOpModel()
        {
            Operate = value ? 1 : 0,
            Type = RadioStationOpType.OpenClose,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.RadioStation_OP);
    }

   
}
