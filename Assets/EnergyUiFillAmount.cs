using Energy;
using UnityEngine;
using UnityEngine.UI;

public class EnergyUiFillAmount : MonoBehaviour
{
    public EnergyController energy;
    public Image image;
    
    private void OnEnable()
    {
        energy.CurrentEnergyChangeEvent += OnDamage;
    }

    private void OnDisable()
    {
        energy.CurrentEnergyChangeEvent -= OnDamage;
    }

    private void OnDamage(float obj)
    {
        image.fillAmount = energy.GetPercentage();
    }
}