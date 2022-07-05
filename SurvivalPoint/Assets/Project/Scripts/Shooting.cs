using System;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera _camera;
    
    private void Awake()
    {
        _camera = Camera.main;
    }

    public void Shoot(Vector2 targetOnScreen)
    {
        Vector2 target = _camera.ScreenToWorldPoint(targetOnScreen);
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        
        Debug.Log($"Shoot to {direction} by {gameObject.name}.");
    }
}