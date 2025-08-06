using UnityEngine;

public class LoadZoneLogic : MonoBehaviour
{

    [SerializeField] SceneEnum ifUnloadedLoadScene;
    [SerializeField] SceneEnum ifLoadedUnloadScene;
    void Awake()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color =new Color(1, 0.92f, 0.016f, 0.5f);
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (ifLoadedUnloadScene != SceneEnum.NONE)
                PersitentLoader.instance.LoadToUnload(ifLoadedUnloadScene);

            if (ifUnloadedLoadScene != SceneEnum.NONE)
                PersitentLoader.instance.UnLoadToLoad(ifUnloadedLoadScene);
        }
    }
}
