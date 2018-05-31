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
    private GridLayoutGroup _roomLayoutGroup;
    private GameObject _roomItemPrefab;
    private float roomItemHeight;

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

        _roomLayoutGroup = transform.Find("RoomList/ScrollRect/Layout").GetComponent<GridLayoutGroup>();

        _roomItemPrefab = Resources.Load<GameObject>("UIPanel/RoomItem");
        roomItemHeight = _roomItemPrefab.GetComponent<RectTransform>().sizeDelta.y;
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


    /// <summary>
    /// 创建房间
    /// </summary>
    private void CreateRoomBtnClick()
    {
        _uiManager.PushPanel(UIPanelType.Room);
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


    private void LoadRoomItem(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject roomItem = Instantiate(_roomItemPrefab);
            roomItem.transform.SetParent(_roomLayoutGroup.transform);
        }


        int roomCount = GetComponentsInChildren<RoomItem>().Length;
        Vector2 size = _roomLayoutGroup.GetComponent<RectTransform>().sizeDelta;
        Debug.Log(roomCount * (_roomItemPrefab.GetComponent<RectTransform>().sizeDelta.y + _roomLayoutGroup.spacing.y));
        _roomLayoutGroup.GetComponent<RectTransform>().sizeDelta = new Vector2(size.x,
            roomCount * (_roomItemPrefab.GetComponent<RectTransform>().sizeDelta.y + _roomLayoutGroup.spacing.y));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadRoomItem(1);
        }
    }
}