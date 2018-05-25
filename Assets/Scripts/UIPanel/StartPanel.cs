using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;

public class StartPanel : BasePanel
{
    private Button _btnLogin;
//    private Animator _btnAnimator;

    public override void OnEnter()
    {
        base.OnEnter();
        _btnLogin = gameObject.GetComponent<Button>();
        _btnLogin.onClick.AddListener(OnLiginBtnClick);
//        _btnAnimator = transform.GetComponent<Animator>();
    }

    private void OnLiginBtnClick()
    {
        _uiManager.PushPanel(UIPanelType.Login);
    }

    public override void OnPause()
    {
        base.OnPause();
//        _btnAnimator.enabled = false;
        Tweener tweener = transform.DOScale(0, 0.5f);
        tweener.OnComplete(() =>
        {
            _btnLogin.enabled = false;
            gameObject.SetActive(false);
        });
    }

    public override void OnResume()
    {
        base.OnResume();

        gameObject.SetActive(true);
        Tweener tweener = transform.DOScale(1, 0.5f);
        tweener.OnComplete(() =>
        {
            _btnLogin.enabled = true;
//            _btnAnimator.enabled = true;
        });
    }
}