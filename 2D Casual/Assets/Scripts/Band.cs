using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Band : MonoBehaviour
{
    public static int BandVisible = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Band.BandVisible == 1)
        {
            GetComponent<LineRenderer>().enabled = false;
        }
        else
        {
            GetComponent<LineRenderer>().enabled = true;
        }
    }
}