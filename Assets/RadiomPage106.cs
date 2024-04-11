using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadiomPage106 : MonoBehaviour
{
    public Toggle kaiguan;

    public Toggle alarm;

    public Toggle totalAlarm;
    public Toggle elec;

    public ButtonBase close;

    public Toggle check;

    /// <summary>
    /// 剂量率阈值
    /// </summary>
    public InputField dose;

    /// <summary>
    /// 累计剂量率阈值
    /// </summary>
    public InputField totalDose;

    /// <summary>
    /// 设置按钮
    /// </summary>
    public ButtonBase setBtn;

    /// <summary>
    /// 当前剂量率显示
    /// </summary>
    public Text curRateText;

    private void Awake()
    {
        close.RegistClick(OnClickClose);
        kaiguan.onValueChanged.AddListener(OnKaiGuanValueChanged);
        alarm.onValueChanged.AddListener(OnAlarmValueChanged);
        totalAlarm.onValueChanged.AddListener(OnTotalAlarmValueChanged);
        elec.onValueChanged.AddListener(OnElecValueChanged);
        check.onValueChanged.AddListener(OnCheckValueChanged);
        setBtn.RegistClick(OnClickSetBtn);
        NetManager.GetInstance().AddNetMsgEventListener(ServerType.LocalServer, NetProtocolCode.SEND_RADIOM_RATE, OnRevRadiomRate);
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
        SendOperateMsg(RadiomOpType106.kaiguanji, value ? 1 : 0);
    }

    /// <summary>
    /// 剂量率报警
    /// </summary>
    private void OnAlarmValueChanged(bool value)
    {
        SendOperateMsg(RadiomOpType106.alarm, value ? 1 : 0);
    }

    /// <summary>
    /// 累计剂量率报警
    /// </summary>
    private void OnTotalAlarmValueChanged(bool value)
    {
        SendOperateMsg(RadiomOpType106.TotalRateAlarm, value ? 1 : 0);
    }

    /// <summary>
    /// 上电
    /// </summary>
    private void OnElecValueChanged(bool value)
    {
        SendOperateMsg(RadiomOpType106.Elec, value ? 1 : 0);
    }

    /// <summary>
    /// 自检
    /// </summary>
    private void OnCheckValueChanged(bool value)
    {
        SendOperateMsg(RadiomOpType106.Check, value ? 1 : 0);
    }

    /// <summary>
    /// 下发操作消息
    /// </summary>
    private void SendOperateMsg(int opType, int operate)
    {
        RadiomeOp106Model opModel = new RadiomeOp106Model()
        {
            Operate = operate,
            Type = opType,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.RADIOME_OP_106);
    }

    private void OnClickSetBtn(GameObject obj)
    {
        SetDoseThreshold set = new SetDoseThreshold()
        {
            DoseThreshold = dose.text.ToFloat(),
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(set), NetProtocolCode.SET_RADIOM_RATE_THRESHOLD_106);

        SetTotalDoseThreshold setTotal = new SetTotalDoseThreshold()
        {
            TotalDoseThreshold = totalDose.text.ToFloat(),
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(setTotal), NetProtocolCode.SET_TT_RADIOM_RATE_THRESHOLD_106);
    }

    /// <summary>
    /// 接收辐射剂量率
    /// </summary>
    private void OnRevRadiomRate(IEventParam param)
    {
        if (param is TcpReceiveEvParam tcpPram)
        {
            SetDoseRateModel model = JsonTool.ToObject<SetDoseRateModel>(tcpPram.netData.Msg);
            curRateText.text = "当前辐射剂量率为：" + model.DoseRate + "  uGy/h";
        }
    }

    private void OnDestroy()
    {
        NetManager.GetInstance().RemoveNetMsgEventListener(ServerType.LocalServer, NetProtocolCode.SEND_RADIOM_RATE, OnRevRadiomRate);
    }
}
