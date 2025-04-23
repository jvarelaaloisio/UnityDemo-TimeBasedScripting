using System.Collections;
using UnityEngine;

namespace Coroutines
{
    public class AnimateCube : MonoBehaviour
    {
        [SerializeField] private float speed = 10;
        [SerializeField] private Transform cube;
        
        //Coroutines are automatically disabled when Components are disabled.
        //Also, components are disabled when their GameObject is deactivated.
        private void OnEnable() => StartCoroutine(Rotate());

        private IEnumerator Rotate()
        {
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
