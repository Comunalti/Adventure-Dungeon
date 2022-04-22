using System;
using UnityEngine;

public class Stateless : MonoBehaviour
{
    public float[] values;
    public int size;
    public float angle;
    [SerializeField] private float max;

    public event Action StatelessChanged;
    public event Action StatelessReseted;
    private void LateUpdate()
    {
    }

    
    private void Start()
    {
        
        this.values = new float[this.size];
        this.angle = Mathf.PI * 2f / this.size;
        
    }

    public Stateless(int resolution)
    {
        this.size = resolution;
        this.values = new float[resolution];
        this.angle = Mathf.PI * 2f / resolution;
    }

    public float GetRadAngle(int i)
    {
        return angle*i;
    }
    
    public Vector2 GetDirection(int i)
    {
        var value = GetRadAngle(i);
        return new Vector2(Mathf.Cos(value),Mathf.Sin(value));
    }
    public Vector2 GetValueAsVector(int i)
    {
        return GetDirection(i)*values[i];
    }


    public void AddVector(Vector2 vector2)
    {
        for (int i = 0; i < size; i++)
        {
            values[i] += Mathf.Clamp(Vector2.Dot(GetDirection(i), vector2),0,max);
        }
        StatelessChanged?.Invoke();
    }
    
    #region testing

    [ContextMenu("Add Right vector")]
    public void AddRightVector()
    {
        AddVector(Vector2.right);
    }

    [ContextMenu("Add Left vector")]
    public void AddLeftVector()
    {
        AddVector(Vector2.left);
    }

    [ContextMenu("Add Up vector")]
    public void AddUpVector()
    {
        AddVector(Vector2.up);
    }

    [ContextMenu("Add Down vector")]
    public void AddDownVector()
    {
        AddVector(Vector2.down);
    }

    #endregion

    public Vector2 GetMaxInterpolatedVector()
    {
        // var currentIndex = GetMaxIndex();
        // var nextIndex = (currentIndex + size + 1)%size;
        // var previousIndex = (currentIndex + size - 1)%size;
        //
        // //print($"current:{currentIndex},next:{nextIndex},previous:{previousIndex}");
        //
        // Vector2 currentVector = GetValueAsVector(currentIndex);
        // Vector2 nextVector = GetValueAsVector(nextIndex);
        // Vector2 previousVector = GetValueAsVector(previousIndex);
        //
// return (currentVector + nextVector + previousVector)/3f;


        Vector2 value = Vector2.zero;
        for (int i = 0; i < size; i++)
        {
            value += GetValueAsVector(i);
        }

        return value/size;
    }

    public int GetMaxIndex()
    {
        int index = 0;
        float value = values[0];
        for (int i = 1; i < size; i++)
        {
            var f = Mathf.Abs(values[i]);
            if (value<f)
            {
                value = f;
                index = i;
            }
        }
        return index;
    }

    public void ResetValues()
    {
        for (int i = 0; i < size; i++)
        {
            values[i] = 0;
        }
        
        StatelessReseted?.Invoke();
    }

    public void Result(Stateless followStateless, Stateless avoidStateless)
    {
        for (int i = 0; i < size; i++)
        {
            values[i] = followStateless.values[i] - avoidStateless.values[i];
        }

        StatelessChanged ?.Invoke();
    }

    public void Result(Stateless followStateless, Stateless avoidStateless, float followMultiplier, float avoidMultiplier)
    {
        for (int i = 0; i < size; i++)
        {
            values[i] = followStateless.values[i]* followMultiplier- avoidStateless.values[i]*avoidMultiplier;
        }

        StatelessChanged ?.Invoke();
    }
}