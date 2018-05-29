using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RoomListPanel : BasePanel
{
    private RectTransform _leftTransform;
    private RectTransform _rightTransform;

    public override void OnEnter()
    {
        base.OnEnter();
        gameObject.SetActive(true);
        _leftTransform = transform.Find("BattleRes").GetComponent<RectTransform>();
        _rightTransform = transform.Find("RoomList").GetComponent<RectTransform>();
        EnterAnim();
    }


    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnPause()
    {
        base.OnPause();
    }

    public override void OnResume()
    {
        base.OnResume();
    }


    private void EnterAnim()
    {
        _leftTransform.localPosition = new Vector3(-1000, 0, 0);
        _leftTransform.DOMoveX(-400, 0.5f);

        _rightTransform.localPosition = new Vector3(1000, 0, 0);
        _leftTransform.DOMoveX(144, 0.5f);
    }


    private void QuitAnim()
    {
        _leftTransform.DOMoveX(-400, 0.5f);
    }
}