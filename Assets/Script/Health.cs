using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IHealth
{
    // Champs
    [SerializeField] int _startHealth;
    [SerializeField] int _maxHealth;
    [SerializeField] UnityEvent _onDeath;

    // Propriétés
    public int CurrentHealth { get; private set; }
    public int MaxHealth => _maxHealth;

    public int HealPotion = 2;
    public bool IsDead => CurrentHealth <= 0;
    // Add boll OnDef
    public bool OnDef = false;

    // Events
    public event UnityAction OnSpawn;
    public event UnityAction<int> OnDamage;
    public event UnityAction<int> OnHealth;
    public event UnityAction OnDeath { add => _onDeath.AddListener(value); remove => _onDeath.RemoveListener(value); }

    // Methods
    void Awake() => Init();

    void Init()
    {
        CurrentHealth = _startHealth;
        OnSpawn?.Invoke();
    }

    public void TakeDamage(int amount)
    {
        if (OnDef == false)
        {
            if (amount < 0) throw new ArgumentException($"Argument amount {nameof(amount)} is negativ");

            var tmp = CurrentHealth;
            CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
            var delta = CurrentHealth - tmp;
            OnDamage?.Invoke(delta);

            if (CurrentHealth <= 0)
            {
                _onDeath?.Invoke();
            }
        }

    }
    //method Gain Health quand on ramasse une potion
    public void GainHealth()
    {
       
            if (HealPotion < 0) throw new ArgumentException($"Argument amount {nameof(HealPotion)} is negativ");

            var tmp = CurrentHealth;
            CurrentHealth = Mathf.Clamp(HealPotion + tmp, 0 , MaxHealth);
            var delta = CurrentHealth;
            OnHealth?.Invoke(delta);
    }

    [Button("test")]
    void MaFonction()
    {
        var enumerator = MesIntPrefere();

        while(enumerator.MoveNext())
        {
            Debug.Log(enumerator.Current);
        }
    }


    List<IEnumerator> _coroutines;

    IEnumerator<int> MesIntPrefere()
    {

        //

        var age = 12;

        yield return 12;


        //

        yield return 3712;

        age++;
        //

        yield return 0;



        //
        yield break;
    }





}
