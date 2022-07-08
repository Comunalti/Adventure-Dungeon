using UnityEngine;
using UnityEngine.UI;

public class EnergyUiFillAmount : MonoBehaviour
{
    public Energy energy;
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