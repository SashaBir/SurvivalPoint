using UnityEngine;

public static class Calculator
{
    public static float GetForceWithMass(float mass, float lenght, float gravityScale)
    {
        float g = -Physics2D.gravity.y;
            
        float force = Mathf.Sqrt(2 * (mass * g * lenght * mass * gravityScale));
            
        return force;
        //return Mathf.Sqrt(_height * -2 * (Physics2D.gravity.y * _rigidbody.gravityScale));
    }
}