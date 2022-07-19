using System;
using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _minimumRadius;

    public void Shoot(IShootable shootable, Vector2 target)
    {
        Transform t = shootable.Self.transform;
        
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        t.position = PositionMinimumAttackedRadius(direction);

        Vector2 initial = t.position;
        Vector2 final = (Vector2)t.position + direction * shootable.Lenght;
        
        shootable.Take();
        
        StartCoroutine(Shoot(shootable, initial, final));
    }

    private Vector2 PositionMinimumAttackedRadius(Vector2 direction)
    {
        return (Vector2)transform.position + direction * _minimumRadius;
    }

    private IEnumerator Shoot(IShootable shootable, Vector2 initial, Vector2 final)
    {
        Rigidbody2D rigidbody = shootable.SelfRigidbody;
        float speed = shootable.Speed;
        float expendedTime = 0;
        
        do
        {
            expendedTime += Time.deltaTime;
            
            float lerpRatioPosition = expendedTime / speed;
            Vector2 position = Vector2.Lerp(initial, final, lerpRatioPosition);
            
            rigidbody.MovePosition(position);
            
            yield return null;
        }
        while (expendedTime <= speed && shootable.IsHitted == false);
        
        rigidbody.velocity = Vector2.zero;
        
        print("STOP");
    }
}