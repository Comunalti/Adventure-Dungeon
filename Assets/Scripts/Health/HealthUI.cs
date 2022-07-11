using UnityEngine;
using UnityEngine.UI;

namespace Health
{
    public class HealthUI : MonoBehaviour
    {
        public HealthController healthController;
        public Slider slider;

        private void OnEnable()
        {
            healthController.RemoveHpEvent += RefreshUI;
            healthController.AddHpEvent += RefreshUI;
        }

        private void OnDisable()
        {
            healthController.RemoveHpEvent -= RefreshUI;
            healthController.AddHpEvent -= RefreshUI;
        }
    
        private void RefreshUI(float dmg)
        {
            slider.value = healthController.GetPercentage();
        }
    }
}

