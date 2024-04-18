using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Page106 : MonoBehaviour
{
    /// <summary>
    /// 关闭
    /// </summary>
    public ButtonBase closeBtn;

    /// <summary>
    /// 电源
    /// </summary>
    public ButtonBase powerBtn;

    public GameObject powerPage;

    /// <summary>
    /// 毒剂报警器
    /// </summary>
    public ButtonBase PoisonAlarm;

    public GameObject poisonPage;

    /// <summary>
    /// 辐射仪
    /// </summary>
    public ButtonBase RadiomeBtn;

    public GameObject RadiomePage;

    /// <summary>
    /// 辐射仪
    /// </summary>
    public ButtonBase BiologyeBtn;

    public GameObject BiologyPage;
    public ButtonBase diantaiBtn;

    public GameObject diantaiPage;

    
    private void Awake()
    {
        powerBtn.RegistClick(OnClickPower);
        closeBtn.RegistClick(ClickClose);
        PoisonAlarm.RegistClick(OnClickPoisonAlarm);
        RadiomeBtn.RegistClick(OnClickRadiomeBtn);
        BiologyeBtn.RegistClick(OnClickBiologyBtn);
        diantaiBtn.RegistClick(OnClickdiantai);
       
    }


  

    private void OnClickdiantai(GameObject obj)
    {
        diantaiPage.SetActive(true);
    }


    void Start()
    {
        
    }

    private void OnClickPoisonAlarm(GameObject obj)
    {
        poisonPage.SetActive(true);
    }

    private void OnClickRadiomeBtn(GameObject obj)
    {
        RadiomePage.SetActive(true);
    }

    private void OnClickBiologyBtn(GameObject obj)
    {
        BiologyPage.SetActive(true);
    }

    private void ClickClose(GameObject obj)
    {
        gameObject.SetActive(false);
    }

    private void OnClickPower(GameObject obj)
    {
        powerPage.SetActive(true);
    }
}
