using System;
using UnityEngine;
using UnityEngine.UI;

public class AuthorizeButtonViewModel : MonoBehaviour
{
    [SerializeField] private Button _authorizeBtn;
    public event EventHandler onAuthorize; 

    private void OnEnable()
    {
        _authorizeBtn.onClick.AddListener(Authorize);
    }

    private void OnDisable()
    {
        _authorizeBtn.onClick.RemoveAllListeners();
    }

    private void Authorize()
    {
        onAuthorize?.Invoke(this, EventArgs.Empty);
    }
}
