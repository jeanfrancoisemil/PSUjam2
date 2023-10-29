using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
[DefaultExecutionOrder(-1)]
public class TEMP : MonoBehaviour
{
    public static TEMP Instance;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }


}
