using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanel : BasePanel
{
    private Text text;
    private float numStayTime = 3;

    public override void OnEnter()
    {
        base.OnEnter();
        text = GetComponent<Text>();
        text.enabled = false;
        _uiManager.InjectMessagePanel(this);
    }

    /// <summary>
    /// 显示信息
    /// </summary>
    /// <param name="msg">要显示的信息</param>
    /// <param name="time">显示的时间</param>
    public void ShowMessage(string msg, float time = 3)
    {
        text.CrossFadeAlpha(1, 0.01f, false);
        text.color = Color.white;
        text.text = msg;
        text.enabled = true;
        Debug.Log("提示板提示信息:" + msg);
        Invoke("Hide", time);
    }


    private void Hide()
    {
        text.enabled = false;
        text.CrossFadeAlpha(0, 1, false);
    }
}