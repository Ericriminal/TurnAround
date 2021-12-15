using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int keyCount;
    public TMP_Text text;

    void Start()
    {
        keyCount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(keyCount.ToString());
    }

    public void AddObject(string objectTagName) {
        if (objectTagName == "Key")
        {
            keyCount++;
        }
    }

    public bool HasObject(string objectTagName) {
        if (objectTagName == "Key" && keyCount > 0) {
            keyCount--;
            return true;
        }
        return false;
    }
}
