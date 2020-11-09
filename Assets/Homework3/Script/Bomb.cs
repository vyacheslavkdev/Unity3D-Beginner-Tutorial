using System;

namespace UnityEngine
{
    public class Bomb : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<BombTarget>() != null)
            {
                other.gameObject.GetComponent<BombTarget>().Boom();
            }

            Destroy(gameObject);
        }
    }
}