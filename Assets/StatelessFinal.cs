using UnityEngine;

public class StatelessFinal : MonoBehaviour
{
    public Stateless avoidStateless;
    public Stateless followStateless;
    public Stateless finalStateless;

    public float avoidMultiplier = 1;
    public float followMultiplier = 1;

    private void Start()
    {
        followStateless.StatelessChanged += StatelessChanged;
        avoidStateless.StatelessChanged += StatelessChanged;
    }

    public void StatelessChanged()
    {
        finalStateless.Result(followStateless,avoidStateless,followMultiplier,avoidMultiplier);
    }
}