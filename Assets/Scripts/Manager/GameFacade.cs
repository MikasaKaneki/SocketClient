using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : MonoBehaviour
{
    private UIManager _uiManager;
    private AudioManager _audioManager;
    private PlayerMananger _playerMananger;
    private CameraManager _cameraManager;
    private RequestManager _requestManager;
    private ClientManager _clientManager;

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
        _uiManager = new UIManager();
        _uiManager.OnInit();

        _audioManager = new AudioManager();
        _audioManager.OnInit();

        _playerMananger = new PlayerMananger();
        _playerMananger.OnInit();

        _cameraManager = new CameraManager();
        _cameraManager.OnInit();

        _requestManager = new RequestManager();
        _requestManager.OnInit();

        _clientManager = new ClientManager();
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
}