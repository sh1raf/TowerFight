using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlayerBullet : Bullet
{
    protected override Vector2 GetCurrentDirection()
    {
        return new Vector2(Mathf.Acos(transform.rotation.z), -Mathf.Asin(transform.rotation.z));
    }
}
