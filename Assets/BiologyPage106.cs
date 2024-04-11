using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BiologyPage106 : MonoBehaviour
{
    public Toggle kaiguan;

    public Toggle alarm;

   

    public ButtonBase close;

    /// <summary>
    /// 生物模拟器数据监测
    /// </summary>
    public InputField dose;

   

    /// <summary>
    /// 设置按钮
    /// </summary>
    public ButtonBase setBtn;

    private void Awake()
    {
        kaiguan.onValueChanged.AddListener(OnKaiGuanValueChanged);
        alarm.onValueChanged.AddListener(OnBiologyValueChanged);
       
        close.RegistClick(OnClickClose);
        setBtn.RegistClick(OnClickSetBtn);
    }

    private void OnClickSetBtn(GameObject obj)
    {
        SetBiologyThreShold106Model set = new SetBiologyThreShold106Model()
        {
            BiologicalData = dose.text.ToFloat(),
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(set), NetProtocolCode.SET_Biology_RATE_THRESHOLD_106);

      
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
        BiologyOp106Model opModel = new BiologyOp106Model()
        {
            Operate = value ? 1 : 0,
            Type = BiologyOp106Type.kaiguanji,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.Biology_OP_106);
    }

    /// <summary>
    /// 上电
    /// </summary>
    private void OnBiologyValueChanged(bool value)
    {
        BiologyOp106Model opModel = new BiologyOp106Model()
        {
            Operate = value ? 1 : 0,
            Type = BiologyOp106Type.alarm,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.Biology_OP_106);
    }


   
}
