using UnityEngine;
using UnityEngine.UI;

namespace Energy
{
    public class EnergyUiImage : MonoBehaviour
    {
        public EnergyController energy;
        public Image image;

        private void OnEnable()
        {
            energy.EnergyChangedEvent += UpdateUI;
        }

        private void OnDisable()
        {
            energy.EnergyChangedEvent -= UpdateUI;
        }

        public void UpdateUI()
        {
            image.fillAmount = energy.GetPercentage();
        }
    }
}
