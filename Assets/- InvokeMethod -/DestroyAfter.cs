using System;
using UnityEngine;

namespace InvokeMethod
{
    public class DestroyAfter : MonoBehaviour
    {
        [SerializeField] private float lifeTime = 1f;

        private void Start()
        {
            Destroy(gameObject, lifeTime);
        }
    }
}