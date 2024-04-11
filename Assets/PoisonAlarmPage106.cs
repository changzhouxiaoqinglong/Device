using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PoisonAlarmPage106 : MonoBehaviour
{
    /// <summary>
    /// 开关机
    /// </summary>
    public Toggle kaiguan;

    /// <summary>
    /// 进气口保护罩
    /// </summary>
    public Toggle jinqimao;

    /// <summary>
    /// 零气
    /// </summary>
    public Toggle lingqi;

    /// <summary>
    /// 氮气
    /// </summary>
    public Toggle danqi;

    /// <summary>
    /// 进样
    /// </summary>
    public Toggle jinyang;

    public Toggle alarm;

    public ButtonBase close;

    public Toggle check;

    public Toggle Elec;

    /// <summary>
    /// 进样情况
    /// </summary>
    public Toggle jinyangStatus;
    private void Awake()
    {
        close.RegistClick(OnClickClose);
        check.onValueChanged.AddListener(OnClickCheck);
        jinqimao.onValueChanged.AddListener(OnJinQiValueChanged);
        danqi.onValueChanged.AddListener(OnDanQiValueChanged);
        lingqi.onValueChanged.AddListener(OnLingQiValueChanged);
        kaiguan.onValueChanged.AddListener(OnKaiGuanValueChanged);
        jinyang.onValueChanged.AddListener(OnJinYangValueChanged);
        alarm.onValueChanged.AddListener(OnAlarmValueChanged);
        Elec.onValueChanged.AddListener(OnElecValueChanged);
        //jinyangStatus.onValueChanged.AddListener(OnInStatusValueChanged);
    }

    private void OnClickClose(GameObject obj)
    {
        gameObject.SetActive(false);
    }

    private void OnClickCheck(bool value)
    {
        SendOperateMsg(PoisonAlarmOp106Type.Check, value ? 1 : 0);
    }

    /// <summary>
    /// 进气帽
    /// </summary>
    private void OnJinQiValueChanged(bool value)
    {
        SendOperateMsg(PoisonAlarmOp106Type.jinqi, value ? 1 : 0);
    }


    /// <summary>
    /// 氮气
    /// </summary>
    private void OnDanQiValueChanged(bool value)
    {
        SendOperateMsg(PoisonAlarmOp106Type.danqi, value ? 1 : 0);
    }

    /// <summary>
    /// 气
    /// </summary>
    private void OnLingQiValueChanged(bool value)
    {
        SendOperateMsg(PoisonAlarmOp106Type.lingqi, value ? 1 : 0);
    }

    /// <summary>
    /// 开关
    /// </summary>
    private void OnKaiGuanValueChanged(bool value)
    {
        SendOperateMsg(PoisonAlarmOp106Type.kaiguanji, value ? 1 : 0);
    }

    /// <summary>
    /// 进样
    /// </summary>
    private void OnJinYangValueChanged(bool value)
    {
        SendOperateMsg(PoisonAlarmOp106Type.jinyang, value ? 1 : 0);
    }

    /// <summary>
    /// 报警
    /// </summary>
    private void OnAlarmValueChanged(bool value)
    {
        SendOperateMsg(PoisonAlarmOp106Type.alarm, value ? 1 : 0);
    }

    /// <summary>
    /// 上电
    /// </summary>
    private void OnElecValueChanged(bool value)
    {
        SendOperateMsg(PoisonAlarmOp106Type.EleOn, value ? 1 : 0);
    }

    /// <summary>
    /// 进样情况
    /// </summary>
    private void OnInStatusValueChanged(bool value)
    {
        PoisonInStatusModel model = new PoisonInStatusModel()
        {
            Status = value ? 1 : 0,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(model), NetProtocolCode.POISON_IN_STATUS);
    }

    /// <summary>
    /// 下发操作消息
    /// </summary>    
    private void SendOperateMsg(int opType, int operate)
    {
        PoisonAlarmOp106Model opModel = new PoisonAlarmOp106Model()
        {
            Operate = operate,
            Type = opType,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.POISON_ALARM_OP_106);
    }
}
