using Managers;
using UnityEngine;


public class GunDropped : MonoBehaviour
{
    public GameObject gunPrefab;
    public GameObject availableSlot;


    private void addGunToSlot()
    {
        gameObject.transform.parent = getAvailableSlot().transform;
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //InputManager.Instance.EPressEvent += addGunToSlot;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        //InputManager.Instance.EPressEvent -= addGunToSlot;
    }

    private GameObject getAvailableSlot()
    {
        return availableSlot;
    }
}
