using UnityEngine;
using Unity.Cinemachine;
public class PersistentVar : MonoBehaviour
{
    static public PersistentVar instance;
    [SerializeField] public CinemachineCamera SubCam2D;
    [SerializeField] public CinemachineCamera SubCam2DZoom;
    [SerializeField] public CinemachineCamera FPCam;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("WARNING, THERE ARE 2 PERSITENTVARS");
        }
    }
    
    public Vector3 GetFPFoward()
    {
        return FPCam.transform.forward;
    }

    public Vector3 GetFPRight()
    {
        return FPCam.transform.right;
    }

}
