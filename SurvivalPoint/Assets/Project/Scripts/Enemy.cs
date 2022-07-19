using System;
using System.Collections;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private Shooting _shooting;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _shootingDelay;
    
    private Player _player;
    private DiContainer _diContainer;

    private bool IsAlivePlayer => _player != null;
    
    [Inject]
    private void Construct(Player player, DiContainer diContainer)
    {
        _player = player;
        _diContainer = diContainer;
    }

    private void Awake()
    {
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        if (IsAlivePlayer == false)
        {
            return;
        }
        
        Vector2 direction = (_player.transform.position - transform.position).normalized;
        _movement.Direction = direction;
    }

    private IEnumerator Shoot()
    {
        while (IsAlivePlayer == true)
        {
            Bullet bullet = _diContainer
                .InstantiatePrefab(_bullet, transform.position, Quaternion.identity, null)
                .GetComponent<Bullet>();
            
            _shooting.Shoot(bullet, _player.transform.position);

            yield return new WaitForSeconds(_shootingDelay);
        }
    }
}