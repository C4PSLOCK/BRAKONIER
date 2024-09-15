using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fox_animation : MonoBehaviour
{
    private Animator anim;

    public string[] staticDirection = { "staticN", "staticWN", "staticW", "staticSW", "staticS", "staticES", "staticE", "staticNE" };
    public string[] runDirection = { "runN", "runWN", "runW", "runSW", "runS", "runES", "runE", "runNE" };

    int lastDirection;
    private void Awake()
    {
        anim = GetComponent<Animator>();

        float result1 = Vector2.SignedAngle(Vector2.up, Vector2.right);
        Debug.Log("R1 " + result1);

        float result2 = Vector2.SignedAngle(Vector2.up, Vector2.left);
        Debug.Log("R2 " + result2);

        float result3 = Vector2.SignedAngle(Vector2.up, Vector2.down);
        Debug.Log("R3 " + result3);
    }
    public void SetDirection(Vector2 _direction)
    {
        string[] directionsArray = null;
        if (_direction.magnitude < 0.01)
        {
            directionsArray = staticDirection;
        }
        else { 
        directionsArray = runDirection;

            lastDirection = DirectionToIndex(_direction);
        }
        anim.Play(directionsArray[lastDirection]);
    }
    private int DirectionToIndex(Vector2 _direction)
    {
        Vector2 noDir =_direction.normalized;
        float step = 360 / 8;
        float offset = step / 2;

        float angle = Vector2.SignedAngle(Vector2.up, noDir);

        angle += offset;
        if (angle < 0) 
        {
            angle += 360;

        }

        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }
}
