using DG.Tweening;
using Share;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : BasePanel
{
    private Button _btnRegister;
    private Button _btnClose;
    private InputField _inputFieldName;
    private InputField _inputFieldPassword;
    private InputField _inputFieldPassword2;
    private RegisterRequest _registerRequest;

    private void Start()
    {
        _btnClose = transform.Find("btn_Close").GetComponent<Button>();
        _inputFieldName = transform.Find("InputUserName").GetComponent<InputField>();
        _inputFieldPassword = transform.Find("InputPassword").GetComponent<InputField>();
        _inputFieldPassword2 = transform.Find("InputPasswordAgain").GetComponent<InputField>();
        _btnRegister = transform.Find("btn_Register").GetComponent<Button>();

        _btnClose.onClick.AddListener(CloseBtnClick);
        _btnRegister.onClick.AddListener(RegisterBtnClick);

        _registerRequest = GetComponent<RegisterRequest>();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        gameObject.SetActive(true);
        transform.localScale = Vector3.zero;
        transform.DOScale(1, 0.5f);
        transform.localPosition = new Vector3(1000, 0, 0);
        transform.DOLocalMove(Vector3.zero, 0.5f);
    }


    private void CloseBtnClick()
    {
        PlayClickSound();
        transform.DOScale(Vector3.zero, 0.5f);
        Tweener tweener = transform.DOLocalMoveX(1000, 0.5f);
        tweener.OnComplete(delegate { _uiManager.PopPanel(); });
    }

    private void RegisterBtnClick()
    {
        PlayClickSound();
        Debug.Log("注册按钮");
        string msg = "";
        if (string.IsNullOrEmpty(_inputFieldName.text))
        {
            msg += "用户名不能是空";
        }

        if (string.IsNullOrEmpty(_inputFieldPassword.text))
        {
            msg += "密码不能为空";
        }

        if (string.IsNullOrEmpty(_inputFieldPassword2.text))
        {
            msg += "密码不能为空";
        }

        if (_inputFieldPassword2.text != _inputFieldPassword.text)
        {
            msg += "两次密码不一样";
        }

        if (string.IsNullOrEmpty(msg))
        {
            //没有错误的消息 TODO 发送到服务器
            _registerRequest.SendRequest(_inputFieldName.text, _inputFieldPassword.text);
        }
        else
        {
            //输出提示信息
            _uiManager.ShowMessage(msg);
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        gameObject.SetActive(false);
    }

    public void OnRegisterResponse(ReturnCode returnCode)
    {
        if (returnCode == ReturnCode.Success)
        {
            _uiManager.ShowMessageSync("注册成功");
        }
        else if (returnCode == ReturnCode.Fail)
        {
            _uiManager.ShowMessageSync("注册失败 用户名出现问题");
        }
    }
}