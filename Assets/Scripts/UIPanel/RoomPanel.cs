using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class RoomPanel : BasePanel
{
    //我是Blue
    private Text _bUserName;
    private Text _bTotalCount;
    private Text _bWinCount;
    private Text _rUserName;
    private Text _rTotalCount;
    private Text _rWinCount;

    private Button _btnStartGame;
    private Button _btnQuitGame;

    private Transform _bluePanel;
    private Transform _redPanel;

    private void Start()
    {
        gameObject.SetActive(true);
        Debug.Log("执行RoomPanel Start动画");
        _bUserName = transform.Find("BluePanel/username").GetComponent<Text>();
        _bUserName = transform.Find("BluePanel/totalCount").GetComponent<Text>();
        _bUserName = transform.Find("BluePanel/winCount").GetComponent<Text>();

        _rUserName = transform.Find("RedPanel/username").GetComponent<Text>();
        _rTotalCount = transform.Find("RedPanel/totalCount").GetComponent<Text>();
        _rWinCount = transform.Find("RedPanel/winCount").GetComponent<Text>();

        _btnStartGame = transform.Find("BluePanel/Btn_Start").GetComponent<Button>();
        _btnStartGame.onClick.AddListener(OnStartGameBtnClick);

        _btnQuitGame = transform.Find("RedPanel/Btn_Quit").GetComponent<Button>();
        _btnQuitGame.onClick.AddListener(OnQuitGameBtnClick);
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("执行RoomPanel OnEnter动画");
        EnterAnim();
    }

    private void OnStartGameBtnClick()
    {
    }

    private void OnQuitGameBtnClick()
    {
        QuitAnim();
    }


    private void SetRedPlayerInfo(string username, string totalCount, string winCount)
    {
        _rUserName.text = username;
        _rTotalCount.text = "总场数:" + totalCount;
        _rWinCount.text = "胜利数:" + winCount;
    }

    private void SetRedPlayerInfo(string username, int totalCount, int winCount)
    {
        _rUserName.text = username;
        _rTotalCount.text = "总场数:" + totalCount.ToString();
        _rWinCount.text = "胜利数:" + winCount.ToString();
    }

    private void SetBluePlayerInfo(string username, string totalCount, string winCount)
    {
        _bUserName.text = username;
        _bTotalCount.text = "总场数:" + totalCount;
        _bWinCount.text = "胜利数:" + winCount;
    }

    private void SetBluePlayerInfo(string username, int totalCount, int winCount)
    {
        _bUserName.text = username;
        _bTotalCount.text = "总场数:" + totalCount.ToString();
        _bWinCount.text = "胜利数:" + winCount.ToString();
    }

    private void ClearRedPlayerInfo()
    {
        _rUserName.text = "";
        _rTotalCount.text = "总场数:";
        _rWinCount.text = "胜利数:";
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
        gameObject.SetActive(true);
        EnterAnim();
    }


    private void EnterAnim()
    {
        _bluePanel.localPosition = new Vector3(-1000, 0, 0);
        _bluePanel.DOLocalMoveX(-275, 0.5f);

        _redPanel.localPosition = new Vector3(1000, 0, 0);
        _redPanel.DOLocalMoveX(239, 0.5f);
    }

    private void QuitAnim()
    {
        _bluePanel.DOLocalMoveX(-1000, 0.5f);
        _redPanel.DOLocalMoveX(1000, 0.5f).OnComplete(() =>
        {
            gameObject.SetActive(false);
            _uiManager.PopPanel();
        });
    }
}