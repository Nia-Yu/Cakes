using UnityEngine;
using UnityEngine.UI;

public class CookingProgresBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _fill;
    [SerializeField] private float _fillingSpeed;
    [SerializeField] private Color _unfilledColor;
    [SerializeField] private Color _filledColor;

    private float _targetProgress;
    private Color _targetColor;

    public void ReseptProgress()
    {
        _targetProgress = 0;
        _targetColor = _unfilledColor;
    }

    public void OnLayerCookingProgress(float cookingProgress, float neededValue)
    {
        _targetProgress = cookingProgress / neededValue;
        _targetColor = Color.Lerp(_unfilledColor, _filledColor, _targetProgress);
    }

    private void Update()
    {
        _slider.value = Mathf.Lerp(_slider.value, _targetProgress, _fillingSpeed);
        _fill.color = Color.Lerp(_fill.color, _targetColor, _fillingSpeed);
    }
}
