using UnityEngine;

public class LoadZoneLogic : MonoBehaviour
{

    [SerializeField] SceneEnum[] ifUnloadedLoadScene;
    [SerializeField] SceneEnum[] ifLoadedUnloadScene;
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
            foreach(SceneEnum i in ifLoadedUnloadScene)
            {
                if (i != SceneEnum.NONE)
                    PersitentLoader.instance.LoadToUnload(i);
            }

            foreach (SceneEnum i in ifUnloadedLoadScene)
            {
                if (i != SceneEnum.NONE)
                    PersitentLoader.instance.UnLoadToLoad(i);
            }

        }
    }
}
