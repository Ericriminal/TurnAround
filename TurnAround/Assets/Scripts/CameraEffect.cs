using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraEffect : MonoBehaviour
{
    // Start is called before the first frame update
    private PostProcessVolume v;
    private ChromaticAberration ca;

    void Start()
    {
        v = GetComponent<PostProcessVolume>();
        ca = v.profile.GetSetting<ChromaticAberration>();
    }

    // Update is called once per frame

    public IEnumerator changeRotationEffect()
    {
        while (ca.intensity < 2f) {
            ca.intensity.Interp(ca.intensity, ca.intensity + 0.2f, 1f);
            yield return new WaitForSeconds(1f/60f);
        }
        while (ca.intensity > 0f) {
            ca.intensity.Interp(ca.intensity, ca.intensity - 0.2f, 1f);
            yield return new WaitForSeconds(1f/60f);
        }
        yield return null;
    }

}
