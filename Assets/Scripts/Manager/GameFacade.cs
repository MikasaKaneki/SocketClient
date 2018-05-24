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


    public void AddRequest(RequestCode requestCode, BaseRequest request)
    {
        _requestManager.AddRequest(requestCode, request);
    }

    public void RemoveRequest(RequestCode requestCode)
    {
        _requestManager.RemoveRequest(requestCode);
    }

    public void HandleReponse(RequestCode requestCode, string data)
    {
        _requestManager.HandleRequest(requestCode, data);
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
}