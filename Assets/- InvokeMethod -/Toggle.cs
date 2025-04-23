using System;
using System.Collections.Generic;
using UnityEngine;

namespace InvokeMethod
{
    public class Toggle : MonoBehaviour
    {
        [SerializeField] private GameObject[] toggleables;
        [SerializeField] private float delay = .5f;
        [SerializeField] private float period = .75f;

        private void Reset()
        {
            toggleables = new GameObject[transform.childCount];
            for (var i = 0; i < transform.childCount; i++)
                toggleables[i] = transform.GetChild(i).gameObject;
        }

        private void OnEnable()
        {
            InvokeRepeating(nameof(ToggleActives), delay, period);
        }

        private void ToggleActives()
        {
            foreach (var toggleable in toggleables)
            {
                toggleable.SetActive(!toggleable.activeSelf);
            }
        }
    }
}
