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
    private Button _createRoomBtn;
    private Button _refreshRoomBtn;


    private void Start()
    {
        _leftTransform = transform.Find("BattleRes").GetComponent<RectTransform>();
        _rightTransform = transform.Find("RoomList").GetComponent<RectTransform>();

        _closeBtn = transform.Find("RoomList/btnClose").GetComponent<Button>();
        _closeBtn.onClick.AddListener(CloseBtnClick);

        _createRoomBtn = transform.Find("RoomList/CreateRoomBtn").GetComponent<Button>();
        _createRoomBtn.onClick.AddListener(CreateRoomBtnClick);

        _refreshRoomBtn = transform.Find("RoomList/RefreshRoomBtn").GetComponent<Button>();
        _refreshRoomBtn.onClick.AddListener(RefreshRoomBtnClick);
        EnterAnim();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        SetBattleResult();
        gameObject.SetActive(true);
        if (_leftTransform)
        {
            EnterAnim();
        }
    }


    private void CreateRoomBtnClick()
    {
    }

    private void RefreshRoomBtnClick()
    {
    }


    private void CloseBtnClick()
    {
        QuitAnim();
        _uiManager.PopPanel();
    }


    public override void OnExit()
    {
        base.OnExit();
        QuitAnim();
    }

    public override void OnPause()
    {
        base.OnPause();
//        QuitAnim();
    }

    public override void OnResume()
    {
        base.OnResume();
        SetBattleResult();
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
        _leftTransform.DOLocalMoveX(-1000, 0.5f);
        _rightTransform.DOLocalMoveX(1000, 0.5f).OnComplete(() => { gameObject.SetActive(false); });
    }


    private void SetBattleResult()
    {
        UserData userData = _facade.GetUserData();
        transform.Find("BattleRes/UserName").GetComponent<Text>().text = userData.UserName;
        transform.Find("BattleRes/TotalCount").GetComponent<Text>().text = "总场数:" + userData.TotalCount.ToString();
        transform.Find("BattleRes/WinCount").GetComponent<Text>().text = "胜利:" + userData.WinCount.ToString();
    }
}