using UnityEngine;

public class ZoomZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PersistentVar.instance.SubCam2DZoom.gameObject.SetActive(true);
            PersistentVar.instance.SubCam2D.gameObject.SetActive(false);
        }
        
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PersistentVar.instance.SubCam2DZoom.gameObject.SetActive(false);
            PersistentVar.instance.SubCam2D.gameObject.SetActive(true);
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
