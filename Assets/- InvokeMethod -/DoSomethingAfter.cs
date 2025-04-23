using UnityEngine;

namespace InvokeMethod
{
    public class DoSomethingAfter : MonoBehaviour
    {
        [SerializeField] private float delay = 5f;

        [ContextMenu("Invoke")]
        private void InvokeDoSomething()
        {
            Invoke(nameof(DoSomething), delay);
        }

        [ContextMenu("Cancel invoke")]
        private void CancelDoSomething()
        {
            CancelInvoke(nameof(DoSomething));
            Debug.Log("Canceled the DoSomething!");
        }

        private void DoSomething()
        {
            Debug.Log("I'm doing something!");
        }
    }
}