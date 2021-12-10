using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pickup : MonoBehaviour
{
    private HealthSystem _healthSystem;
    [SerializeField] private float _rotationSpeed = 2.0f;
    [SerializeField] private UnityEvent onPickUp = new UnityEvent();

    private void Start()
    {
        _healthSystem = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<HealthSystem>();
    }

    private void Update()
    {
        transform.Rotate(new Vector3(_rotationSpeed, _rotationSpeed, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _healthSystem.currentHealth = _healthSystem.maxHealth;
            onPickUp.Invoke();
            Destroy(this.gameObject);
        }
    }
}
