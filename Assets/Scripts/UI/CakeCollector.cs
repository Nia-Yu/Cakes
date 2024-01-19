using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class CakeCollector : MonoBehaviour
{
    [SerializeField] private CakePlace _cakeplace;
    [SerializeField] private Button _collectButton;

    private Cake _targetCake;
    private CanvasGroup _canvasGroup;

    public event UnityAction<Cake> CakeCollected;

    private void OnEnable()
    {
        _cakeplace.CakeReadyForCollection += OnCakeReadyForCollection;
        _collectButton.onClick.AddListener(CollectCake);
    }

    private void OnDisable()
    {
        _cakeplace.CakeReadyForCollection -= OnCakeReadyForCollection;
        _collectButton.onClick.RemoveListener(CollectCake);
    }

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        Close();
    }

    private void OnCakeReadyForCollection(Cake cake)
    {
        _targetCake = cake;
        Open();
    }

    private void CollectCake()
    {
        CakeCollected?.Invoke(_targetCake);
        Close();
    }

    private void Open()
    {
        _canvasGroup.alpha = 1;
    }

    private void Close()
    {
        _canvasGroup.alpha = 0;
    }
}
