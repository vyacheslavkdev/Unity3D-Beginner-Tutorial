using System;

namespace UnityEngine
{
    public class Bomb : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            other.gameObject.GetComponent<BombTarget>().Boom();
            Destroy(gameObject);
        }
    }
}