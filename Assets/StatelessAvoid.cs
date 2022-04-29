using System.Linq;
using UnityEngine;

public class StatelessAvoid : MonoBehaviour
{
    public Stateless avoidStateless;
    public GameObject Avoid;

    public float avoidMultiplication =1;
    public float avoidMax = 1;

    private void Update()
    {
        avoidStateless.ResetValues();
        
        for (int i = 0; i < avoidStateless.size; i++)
        {
            var direction = avoidStateless.GetDirection(i);
            var results = Physics2D.RaycastAll(transform.position, direction);

            var result = results.FirstOrDefault((hit2D => hit2D.transform != transform));
            
            print($"hit: {result.transform is null}, distance is: {result.distance}, i = {i}");

            if (!(result.transform is null))
            {
                avoidStateless.AddVector(direction * Mathf.Clamp((avoidMultiplication)/result.distance,0,avoidMax));
            }
        }
    }
}