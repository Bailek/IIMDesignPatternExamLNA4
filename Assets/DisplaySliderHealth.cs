using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySliderHealth : MonoBehaviour
{
    // Variable
    [SerializeField] PlayerEntity _player;
    [SerializeField] Slider _slider;

    // upadate a chaque fois que le joueur se soigne ou se fais toucher
    void UpdateDisplayedSliderHealth(int _) => _slider.value  = _player.Health.CurrentHealth;

    private void Start()
    {
        _player.Health.OnDamage += UpdateDisplayedSliderHealth;
        _player.Health.OnHealth += UpdateDisplayedSliderHealth;
        _slider.maxValue = _player.Health.MaxHealth;
        _slider.value = _player.Health.MaxHealth;
    }

    private void OnDestroy()
    {
        _player.Health.OnDamage -= UpdateDisplayedSliderHealth;
        _player.Health.OnHealth -= UpdateDisplayedSliderHealth;
    }

    private void _slider_OnHealthChanged(int obj)
    {
        UpdateDisplayedSliderHealth(obj);
    }
}
