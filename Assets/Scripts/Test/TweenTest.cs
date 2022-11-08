using System;
using Question1;
using UnityEngine;
using UnityEngine.UIElements;

namespace Test
{
    public class TweenTest : MonoBehaviour
    {
        private void Start()
        {
            // Tween.Init.Move(this.gameObject, transform.position, new Vector3(5, 5, 5), 2, false);
            // Tween.Init.Move(this.gameObject, transform.position, new Vector3(5, 5, 5), 2, true);
            // Tween.Init.EaseOutMove(this.gameObject, transform.position, new Vector3(10, 0, 0), 5);
            Tween.Init.EaseInOutMove(this.gameObject, transform.position, new Vector3(10, 0, 0), 5);
        }

        private void Update()
        {
            // Debug.Log(1);
        }
    }
};

