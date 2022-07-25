using System.Collections.Generic;
using UnityEngine;

namespace AI.StateMachine.Machines
{
    public class TimerHandler : MonoBehaviour
    {
        public List<Timer> _timersList = new List<Timer>();
        
        public float GetRemainTimer(string timerTag)
        {
            foreach (var timer in _timersList)
            {
                if (timer.name == timerTag)
                {
                    return timer.current;
                }
            }

            return 0;
        }

        public void ResetTimer(string timerTag)
        {
            var timer = _timersList.Find((timer => timer.name == timerTag));
            //print(timer.name);
            timer.current = timer.max;
        }
        
        private void Update()
        {
            foreach (var timer in _timersList)
            {
                timer.current -= Time.deltaTime;
                timer.current = Mathf.Clamp(timer.current, 0, timer.max);
            }
        }
        
    }
}