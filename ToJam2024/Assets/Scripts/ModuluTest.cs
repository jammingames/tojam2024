using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuluTest : MonoBehaviour
{
    public int[] numbers = new int[5];
    public int moduloI = 1;
    public int k = 2;
    public bool keepRunning = true;
    private void OnValidate()
    {

            for (int i = 0; i < moduloI; i++)
            {
                int index = (i + k) % numbers.Length;
                Debug.Log(numbers.Length + "< numlength . numbers[i] value> " + numbers[index] + "  index => " + index + "\n" +
                          " modulo: " + moduloI + "  i " + i);

            }

    }
    
    
    public int GetRotatedValueAtIndex(int index, int k, int[] list)
    {
        return list[(index + k) % list.Length];
    }
    
    public int[] Rotate(int[] list, int k)
    {
        return 
    }
}
