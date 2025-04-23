using System;
using System.Collections;
using UnityEngine;

namespace Coroutines
{
    public class AnimateCube : MonoBehaviour
    {
        [SerializeField] private float speed = 10;
        [SerializeField] private Transform cube;

        private void Reset() => cube = transform;

        //Coroutines are automatically stopped when their GameObject is deactivated,
        //but not when their component is just disabled.
        //To have that logic, you can modify the While statement to While(enabled){} 
        private void OnEnable() => StartCoroutine(Rotate());

        private IEnumerator Rotate()
        {
            //destroyCancellationToken is an object that can request a cancellation on a process from the outside.
            while (!destroyCancellationToken.IsCancellationRequested)
            {
                var t = Time.time * (speed * Time.deltaTime);
                cube.Rotate(new Vector3(Mathf.Cos(t), Mathf.Sin(t), Mathf.Cos(t)), Space.World);
                
                //This "yields" control to the system. 
                yield return null;
            }
        }
    }
}
