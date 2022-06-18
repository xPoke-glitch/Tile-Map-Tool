using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Because Multidimensional arrays are not serializable 
[System.Serializable]
public class Table<T> where T : class
{
    [SerializeField]
    [Min(1)]
    private int xDimension = 1;

    [SerializeField]
    [Min(1)]
    private int yDimension = 1;

    [SerializeField]
    private T[] flatArray = new T[1];

    public Table() { }

    public Table(T[,] array)
    {
        xDimension = array.GetLength(0);
        yDimension = array.GetLength(1);
        flatArray = new T[xDimension * yDimension];

        for (var x = 0; x < xDimension; x++)
        {
            for (var y = 0; y < yDimension; y++)
            {
                flatArray[x * yDimension + y] = array[x, y];
            }
        }
    }

    public Table(int x, int y)
    {
        xDimension = x;
        yDimension = y;
        flatArray = new T[x * y];
    }

    public Table(T[] array, int x, int y)
    {
        xDimension = x;
        yDimension = y;
        flatArray = array;
    }

    public T this[int x, int y]
    {
        get => flatArray[x * yDimension + y];

        set => flatArray[x * yDimension + y] = value;
    }

    public T[,] GetMatrix()
    {
        T[,] matrix = new T[xDimension, yDimension];

        Debug.Log("Array Length " + flatArray.Length);
        Debug.Log("Matrix dim " + xDimension + " " + yDimension);

        for (var x = 0; x < xDimension; x++)
        {
            for (var y = 0; y < yDimension; y++)
            {
                matrix[x, y] = flatArray[x * yDimension + y];
            }
        }
        return matrix;
    }
}
