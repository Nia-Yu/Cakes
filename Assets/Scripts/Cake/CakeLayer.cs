using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CakeLayer : MonoBehaviour
{
    [SerializeField] private int _clicksBeforeCoocing;

    private SpriteRenderer _spriteRenderer;
    private Color _layerColor;

    public int CookingProgress { get; private set; }
    public int ClicksBeforeCoocing => _clicksBeforeCoocing;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _layerColor = _spriteRenderer.color;
        CreateGhostLayer();
    }

    public void IncreaseCookingProgress()
    {
        CookingProgress++;
    }

    private void CreateGhostLayer()
    {
        _spriteRenderer.color = new Color(256, 256, 256, 45);
    }

    public bool TryCookLayer()
    {
        if(_clicksBeforeCoocing == CookingProgress)
        {
            _spriteRenderer.color = _layerColor;
            return true;
        }
        else
        {
            return false;
        }
    }
}
