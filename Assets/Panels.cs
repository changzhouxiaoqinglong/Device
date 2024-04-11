using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panels : MonoBehaviour
{
    public GameObject page02b;

    public ButtonBase page02bBtn;

    public GameObject page102;

    public ButtonBase page102Btn;

    public GameObject page384;

    public ButtonBase page384Btn;

    public GameObject page106;

    public ButtonBase page106Btn;

    private void Awake()
    {
        page02bBtn.RegistClick(OnClickPage02B);
        page102Btn.RegistClick(OnClickPage102);
        page384Btn.RegistClick(OnClickPage384);
        page106Btn.RegistClick(OnClickPage106);
    }

    private void OnClickPage02B(GameObject obj)
    {
        page02b.SetActive(true);
    }

    private void OnClickPage102(GameObject obj)
    {
        page102.SetActive(true);
    }

    private void OnClickPage384(GameObject obj)
    {
        page384.SetActive(true);
    }

    private void OnClickPage106(GameObject obj)
    {
        page106.SetActive(true);
    }
}
