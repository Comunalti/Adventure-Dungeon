using UnityEngine;
using UnityEngine.UI;

public class EnergyUiFillAmount : MonoBehaviour
{
    public Energy energy;
    public Image image;
    
    private void OnEnable()
    {
        energy.EnergyUseEvent += OnDamage;
        energy.EnergyRechargeEvent += OnDamage;
    }

    private void OnDisable()
    {
        energy.EnergyUseEvent -= OnDamage;
        energy.EnergyRechargeEvent -= OnDamage;
    }

    private void OnDamage(float obj)
    {
        image.fillAmount = energy.GetPercentage();
    }
}