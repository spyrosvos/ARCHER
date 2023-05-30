using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelAnchor : MonoBehaviour
{
    public string text = "hello";
    // Start is called before the first frame update
    void OnEnable() {
        StartCoroutine(LateStart(1));
    }

    IEnumerator LateStart(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        //Your Function You Want to Call
        LabelManager.instance.CreateAnchor(this);
    }

    private void OnDisable() {
        LabelManager.instance.DestroyAnchor(this);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
