using UnityEngine.UI;
using DG.Tweening;
using Share;
using UnityEditor;
using UnityEngine;

public class LoginPanel : BasePanel
{
    private Button _btnLogin;
    private Button _btnRegister;
    private Button _btnClose;
    private InputField _inputFieldUserName;
    private InputField _inputFieldPassword;
    private LoginRequest _loginRequest;

    public override void OnEnter()
    {
        base.OnEnter();
        gameObject.SetActive(true);
        transform.localScale = Vector3.zero;
        transform.DOScale(1, 0.5f);
        transform.localPosition = new Vector3(1000, 0, 0);
        transform.DOLocalMove(Vector3.zero, 0.5f);

        _btnLogin = transform.Find("btn_Login").GetComponent<Button>();
        _btnRegister = transform.Find("btn_Register").GetComponent<Button>();
        _btnClose = transform.Find("btn_Close").GetComponent<Button>();

        _inputFieldUserName = transform.Find("InputUserName").GetComponent<InputField>();
        _inputFieldPassword = transform.Find("InputPassword").GetComponent<InputField>();


        _btnLogin.onClick.AddListener(OnLoginBtnClick);
        _btnRegister.onClick.AddListener(OnRegisterBtnClick);
        _btnClose.onClick.AddListener(OnCloseBtnClick);

        _loginRequest = GetComponent<LoginRequest>();
    }

    public override void OnExit()
    {
        base.OnExit();
        gameObject.SetActive(false);
    }

    private void OnLoginBtnClick()
    {
        Debug.Log("点击登录按钮");
        string msg = "";
        if (string.IsNullOrEmpty(_inputFieldUserName.text))
        {
            msg += "用户名不能是空";
        }

        if (string.IsNullOrEmpty(_inputFieldPassword.text))
        {
            msg += "密码不能为空";
        }

        if (string.IsNullOrEmpty(msg))
        {
            //没有错误的消息 TODO 发送到服务器
        }
        else
        {
            //输出提示信息
            _uiManager.ShowMessage(msg);
        }

        _loginRequest.SendRequest(_inputFieldUserName.text, _inputFieldPassword.text);
    }

    private void OnRegisterBtnClick()
    {
    }

    public void OnLoginResponse(ReturnCode returnCode)
    {
        if (returnCode == ReturnCode.Success)
        {
            //成功进入
        }
        else if (returnCode == ReturnCode.Fail)
        {
            //失败的
            _uiManager.ShowMessageSync("用户名错误，请重新输入！！");
        }
        else if (returnCode == ReturnCode.NotFound)
        {
            _uiManager.ShowMessageSync("密码错误，请重新输入！！");
        }
    }

    private void OnCloseBtnClick()
    {
        transform.DOScale(Vector3.zero, 0.5f);
        Tweener tweener = transform.DOLocalMoveX(1000, 0.5f);
        tweener.OnComplete(delegate { _uiManager.PopPanel(); });
    }
}