using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    private Text _userNameText;
    private Text _battleCountText;
    private Button _joinButton;


    public void Start()
    {
        _userNameText = transform.Find("userName").GetComponent<Text>();
        _battleCountText = transform.Find("BattleCount").GetComponent<Text>();
        _joinButton = transform.Find("btnJoin").GetComponent<Button>();
        _joinButton.onClick.AddListener(JoinRoomBtnClick);
    }

    public void SetRoomInfo(string username, int totalCount, int winCount)
    {
        _userNameText.text = username;
        _battleCountText.text = winCount.ToString() + "/" + totalCount.ToString();
    }

    public void SetRoomInfo(string username, string totalCount, string winCount)
    {
        _userNameText.text = username;
        _battleCountText.text = winCount + "/" + totalCount;
    }

    private void JoinRoomBtnClick()
    {
    }



}