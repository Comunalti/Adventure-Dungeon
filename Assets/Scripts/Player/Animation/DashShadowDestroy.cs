using System;
using System.Collections;
using System.IO;
using UnityEngine;

namespace Player.Animation
{
    public class DashShadowDestroy : MonoBehaviour
    {
        public float duration;
        public float timeLiving;
        public AnimationCurve animationCurve;
        public SpriteRenderer spriteRenderer;
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(duration);
            Destroy(gameObject);
        }

        private void Update()
        {
            timeLiving += Time.deltaTime;
            var percentage = timeLiving/duration;
            spriteRenderer.material.SetFloat("_Percentage",percentage);
        }
    }
}