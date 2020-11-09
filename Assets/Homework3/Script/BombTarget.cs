using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTarget : MonoBehaviour
{
    public void Boom()
    {
        Destroy(gameObject);
    }
}
