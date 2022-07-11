using UnityEngine;
using UnityEngine.UI;

namespace Energy
{
    public class EnergyUISlide : MonoBehaviour
    {
        public EnergyController energy;
        public Slider slider;

        private void OnEnable()
        {
            energy.EnergyChangedEvent += RefreshUI; 
        }

        private void OnDisable()
        {
            energy.EnergyChangedEvent -= RefreshUI;
        }

        private void RefreshUI()
        {
            slider.value = energy.GetPercentage();
        }
    }
}
