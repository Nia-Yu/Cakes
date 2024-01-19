using UnityEngine;
using UnityEngine.Events;

public class CakePlace : MonoBehaviour
{
    [SerializeField] private ClickerZone _clickerZone;
    [SerializeField] private CookingProgresBar _cookingProgresBar;

    private Cake _cake;

    public event UnityAction<Cake> CakeReadyForCollection;

    public void SetCake(Cake cake)
    {
        _cake = Instantiate(cake, transform);
        _cake.CakeDone += OnCakeDone;
        _cake.LayerCookingProgress += _cookingProgresBar.OnLayerCookingProgress;
        _clickerZone.Click += _cake.OnClick;
    }

    public void RemoveCake(Cake cake)
    {
        _cake.CakeDone -= OnCakeDone;
        _cake.LayerCookingProgress -= _cookingProgresBar.OnLayerCookingProgress;
        _clickerZone.Click -= _cake.OnClick;
        Destroy(cake);
    }

    private void OnCakeDone()
    {
        CakeReadyForCollection?.Invoke(_cake);
    }
}
