using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using SceneManagement Engine
using UnityEngine.SceneManagement;

public class PlayerEntity : MonoBehaviour
{
    [SerializeField] Health _health;
    
    public Health Health => _health;

    private void Awake()
    {
        // Ajout de la fonction ReloadOnDeath à OnDeath
        _health.OnDeath += ReloadOnDeath;
    }

    // Fonction ReloadOnDeath quand le personnage meurt
    private void ReloadOnDeath()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}


