using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class RoomListPanel : BasePanel
{
    private RectTransform _leftTransform;
    private RectTransform _rightTransform;
    private Button _closeBtn;

    public override void OnEnter()
    {
        base.OnEnter();
        gameObject.SetActive(true);
        _leftTransform = transform.Find("BattleRes").GetComponent<RectTransform>();
        _rightTransform = transform.Find("RoomList").GetComponent<RectTransform>();
        _closeBtn=transform.Find("RoomList/")
        _closeBtn.onClick.AddListener(() =>
        {
            QuitAnim();
            _uiManager.PopPanel();
        });
        EnterAnim();
    }


    public override void OnExit()
    {
        base.OnExit();
        QuitAnim();
    }

    public override void OnPause()
    {
        base.OnPause();
        QuitAnim();
    }

    public override void OnResume()
    {
        base.OnResume();
        EnterAnim();
    }


    private void EnterAnim()
    {
        _leftTransform.localPosition = new Vector3(-1000, 0, 0);
        _leftTransform.DOLocalMoveX(-400, 0.5f);


        _rightTransform.localPosition = new Vector3(1000, 0, 0);
        _rightTransform.DOLocalMoveX(144, 0.5f);
    }


    private void QuitAnim()
    {
        _leftTransform.DOMoveX(-1000, 0.5f);
        _rightTransform.DOMoveX(1000, 0.5f).OnComplete(() => { gameObject.SetActive(false); });
    }
}