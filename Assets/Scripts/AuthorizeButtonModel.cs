using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine.Networking;
using TMPro;

public class AuthorizeButtonModel : MonoBehaviour
{
    [SerializeField] private AuthorizeButtonViewModel _authorizeButtonViewModel;
    [SerializeField] private TMP_InputField _loginInput;
    [SerializeField] private TMP_InputField _passwordInput;
    [SerializeField] private TMP_Text _resultTxt;

    private string _url;
    private string _pathToLoginData;

    private void OnEnable()
    {
        _url = "https://stage.arenagames.api.ldtc.space/";
        _authorizeButtonViewModel.onAuthorize += DisplayWebRequest;
        _resultTxt.enabled = false;
    }

    private void OnDisable()
    {
        _authorizeButtonViewModel.onAuthorize -= DisplayWebRequest;
    }

    private async void DisplayWebRequest(object sender, System.EventArgs e)
    {
        UserData userData = new UserData();
        if(_loginInput.text == userData.Login && _passwordInput.text == userData.Password)
        {
            _resultTxt.enabled = false;
            string result;
            result = await GetWebRequest(_url, this.GetCancellationTokenOnDestroy());
            Debug.Log(result);
        }
        else
        {
            _resultTxt.enabled = true;
            _resultTxt.text = "Wrong login or password";
        }
    }

    private async UniTask<string> GetWebRequest(string url, CancellationToken token)
    {
        UnityWebRequest request = await UnityWebRequest
            .Get(url)
            .SendWebRequest()
            .WithCancellation(token);

        return request.downloadHandler.text;
    }
}
