using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CakeDispanser : MonoBehaviour
{
    [SerializeField] private CakeCollector _cakeCollector;
    [SerializeField] private CakePlace _cakePlace;
    [SerializeField] private List<Cake> _cakeTemplates;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _cakeCollector.CakeCollected += OnCakeCollected;
        _player.CakeBought += OnCakeBought;
    }

    private void OnDisable()
    {
        _cakeCollector.CakeCollected -= OnCakeCollected;
        _player.CakeBought -= OnCakeBought;
    }

    private void Start()
    {
        DispanceCake();
    }

    private void DispanceCake()
    {
        int randomNumber = Random.Range(0, _cakeTemplates.Count);
        Cake randomCake = _cakeTemplates[randomNumber];
        _cakePlace.SetCake(randomCake);
    }

    private void OnCakeCollected(Cake cake)
    {
        _cakePlace.RemoveCake(cake);
        DispanceCake();
    }

    private void OnCakeBought(Cake cake)
    {
        _cakeTemplates.Add(cake);
    }
}
