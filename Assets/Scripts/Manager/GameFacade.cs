using System.Collections;
using System.Collections.Generic;
using Share;
using UnityEngine;

public class GameFacade : MonoBehaviour
{
    private UIManager _uiManager;
    private AudioManager _audioManager;
    private PlayerMananger _playerMananger;
    private CameraManager _cameraManager;
    private RequestManager _requestManager;
    private ClientManager _clientManager;

    private static GameFacade _instance;

    public static GameFacade Instance
    {
        get { return _instance; }
    }


    public void AddRequest(ActionCode actionCode, BaseRequest request)
    {
        _requestManager.AddRequest(actionCode, request);
    }

    public void RemoveRequest(ActionCode actionCode)
    {
        _requestManager.RemoveRequest(actionCode);
    }

    public void HandleReponse(ActionCode actionCode, string data)
    {
        _requestManager.HandleRequest(actionCode, data);
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
    }

    private void Start()
    {
        InitManager();
    }

    private void Update()
    {
    }

    private void OnDestroy()
    {
        DestroyManager();
    }

    private void InitManager()
    {
        _uiManager = new UIManager(this);
        _uiManager.OnInit();

        _audioManager = new AudioManager(this);
        _audioManager.OnInit();

        _playerMananger = new PlayerMananger(this);
        _playerMananger.OnInit();

        _cameraManager = new CameraManager(this);
        _cameraManager.OnInit();

        _requestManager = new RequestManager(this);
        _requestManager.OnInit();

        _clientManager = new ClientManager(this);
        _clientManager.OnInit();
    }


    private void DestroyManager()
    {
        _uiManager.OnDesory();
        _audioManager.OnDesory();
        _playerMananger.OnDesory();
        _cameraManager.OnDesory();
        _requestManager.OnDesory();
        _clientManager.OnDesory();
    }


    public void ShowMessage(string message)
    {
        _uiManager.ShowMessage(message);
    }


    public void SendRequest(RequestCode requestCode, ActionCode actionCode, string data)
    {
        _clientManager.SendRequest(requestCode, actionCode, data);
    }
}