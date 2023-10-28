using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(-1)]
public class PlayerInputs : MonoBehaviour
{
    public static PlayerInputs Instance;
    public static Player Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = new Player();
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
