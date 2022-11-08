
using System.Collections;
using UnityEngine;

namespace Question1
{
    public class Tween : MonoBehaviour
    {
        public static Tween Init
        {
            get;
            private set;
        }

        public void Awake()
        {
            if (Init != null)
            {
                Destroy(this);
                return;
            }
            Init = this;
        }

        public void Move(GameObject gameObject, Vector3 begin, Vector3 end, float time, bool pingpong)
        {
            
            Vector3 endVector = end - begin;
            if (pingpong)
            {
                StartCoroutine(PingPongMoveEnumerator(gameObject, endVector, time));
                return;
            }
            
            StartCoroutine(MoveEnumerator(gameObject, time, endVector));
        }

        private static IEnumerator MoveEnumerator(GameObject gameObject, float runTime, Vector3 endVector)
        {
            float currentTime  = 0;
            
            while (currentTime  < runTime)
            {
                currentTime  += Time.fixedDeltaTime;
                gameObject.transform.Translate(endVector * (Time.fixedDeltaTime / runTime));
                yield return new WaitForFixedUpdate();
            }
        }

        private static IEnumerator PingPongMoveEnumerator
            (GameObject gameObject, Vector3 endVector, float runTime)
        {
            float currentTime  = 0;
            
            while (true)
            {
                currentTime  += Time.fixedDeltaTime;
                if (currentTime  >= runTime * 2)
                {
                    currentTime  = 0;
                }
                if (currentTime  < runTime)
                {
                    gameObject.transform.Translate(endVector * (Time.fixedDeltaTime / runTime));
                    yield return new WaitForFixedUpdate();
                }
                else
                {
                    gameObject.transform.Translate(-endVector * (Time.fixedDeltaTime / runTime));
                    yield return new WaitForFixedUpdate();
                }
            }
        }
        
        //二次方缓动
        public void EaseInMove(GameObject gameObject, Vector3 begin, Vector3 end, float time)
        {
            Vector3 endVector = end - begin;
            StartCoroutine(EaseInMoveEnumerator(gameObject, time, endVector));
        }

        private static IEnumerator EaseInMoveEnumerator(GameObject gameObject, float runTime, Vector3 endVector)
        {
            float currentTime  = 0;
            Vector3 moveDistance = new Vector3();
            while (currentTime  < runTime)
            {
                currentTime  += Time.fixedDeltaTime;
                var ratio = currentTime / runTime;
                Vector3 distance = endVector * ratio * ratio - moveDistance;
                moveDistance += distance;
                
                gameObject.transform.Translate(distance);
                yield return new WaitForFixedUpdate();
            }
        }

        public void EaseOutMove(GameObject gameObject, Vector3 begin, Vector3 end, float time)
        {
            Vector3 endVector = end - begin;
            StartCoroutine(EaseOutMoveEnumerator(gameObject, time, endVector));
        }

        private static IEnumerator EaseOutMoveEnumerator(GameObject gameObject, float runTime, Vector3 endVector)
        {
            float currentTime  = 0;
            Vector3 moveDistance = endVector;
            while (currentTime  < runTime)
            {
                currentTime  += Time.fixedDeltaTime;
                var ratio = 1 - currentTime / runTime;
                Vector3 distance = moveDistance - endVector * ratio * ratio;
                moveDistance -= distance;
                
                gameObject.transform.Translate(distance);
                yield return new WaitForFixedUpdate();
            }
        }
        
        public void EaseInOutMove(GameObject gameObject, Vector3 begin, Vector3 end, float time)
        {
            Vector3 endVector = end - begin;
            StartCoroutine(EaseInOutMoveEnumerator(gameObject, time, endVector));
        }
        
        private static IEnumerator EaseInOutMoveEnumerator(GameObject gameObject, float runTime, Vector3 endVector)
        {
            float currentTime  = 0;
            Vector3 outMoveDistance = endVector / 2;
            Vector3 inMoveDistance = new Vector3();
            
            while (currentTime < runTime)
            {
                currentTime  += Time.fixedDeltaTime;
                
                Vector3 distance;
                if (currentTime < runTime / 2)
                {
                    var ratio = currentTime / runTime * 2;
                    distance = endVector / 2 * ratio * ratio - inMoveDistance;
                    inMoveDistance += distance;
                }
                else
                {
                    var ratio = 2 - currentTime / runTime * 2;
                    distance = outMoveDistance -  endVector / 2 * ratio * ratio;
                    outMoveDistance -= distance;
                    
                }
                gameObject.transform.Translate(distance);
                yield return new WaitForFixedUpdate();
            }

        }

    }
}