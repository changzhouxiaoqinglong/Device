
using UnityEngine;
using UnityEngine.UI;

public class PowerPage106 : MonoBehaviour
{
    public Toggle kaiguan;

    public Toggle elec;

    public Toggle outPut;

    public ButtonBase close;

    private void Awake()
    {
        kaiguan.onValueChanged.AddListener(OnKaiGuanValueChanged);
        elec.onValueChanged.AddListener(OnElecValueChanged);
        outPut.onValueChanged.AddListener(OnOutPutValueChanged);
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
        PowerOp106Model opModel = new PowerOp106Model()
        {
            Operate = value ? 1 : 0,
            Type = PowerOp106Type.kaiguan,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.POWER_OP_106);
    }

    /// <summary>
    /// 上电
    /// </summary>
    private void OnElecValueChanged(bool value)
    {
        PowerOp106Model opModel = new PowerOp106Model()
        {
            Operate = value ? 1 : 0,
            Type = PowerOp106Type.elec,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.POWER_OP_106);
    }


    /// <summary>
    /// 输出
    /// </summary>
    private void OnOutPutValueChanged(bool value)
    {
        PowerOp106Model opModel = new PowerOp106Model()
        {
            Operate = value ? 1 : 0,
            Type = PowerOp106Type.output,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.POWER_OP_106);
    }
}
