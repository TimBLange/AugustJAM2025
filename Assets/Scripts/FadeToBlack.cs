using UnityEngine;

public class FadeToBlack : MonoBehaviour
{
    private Material mat;
    void Start()
    {
        mat = GetComponent<MeshRenderer>().sharedMaterial;
        mat.SetFloat("_FadeStartPoint", -float.MaxValue);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            mat.SetFloat("_FadeStartPojnt", Time.time);
        }
    }
}
