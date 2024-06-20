using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicScript : MonoBehaviour
{
    public Dictionary<GameObject, float> defaultdrags;

    private void Awake()
    {
        defaultdrags = new Dictionary<GameObject, float>();
    }
}
