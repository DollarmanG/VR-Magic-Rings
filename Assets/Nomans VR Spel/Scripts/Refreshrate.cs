using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public class Refreshrate : MonoBehaviour
{
    public int[] availableRefreshRates; // array of available refresh rates
    public int currentRefreshRateIndex; // index of the currently selected refresh rate

    private void Start()
    {
        // get available refresh rates from Oculus device
        float[] refreshRates = new[] { XRDevice.refreshRate };

        // convert to integers and filter out duplicates
        HashSet<int> uniqueRefreshRates = new HashSet<int>();
        foreach (float rate in refreshRates)
        {
            uniqueRefreshRates.Add((int)rate);
        }

        // convert to array and sort in ascending order
        availableRefreshRates = uniqueRefreshRates.ToArray();
        Array.Sort(availableRefreshRates);

        // set initial refresh rate
        SetRefreshRate(currentRefreshRateIndex);
    }

    public void SetRefreshRate(int index)
    {
        // set current refresh rate index
        currentRefreshRateIndex = index;

        // set refresh rate on Oculus device
        XRSettings.eyeTextureResolutionScale = availableRefreshRates[index];
    }
}