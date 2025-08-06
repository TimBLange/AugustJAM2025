using UnityEngine;

public class SubMovementTest : MonoBehaviour
{
    Rigidbody rB;
    [SerializeField] float speed;
    void Awake()
    {
        rB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");

        Vector3 horVect = Vector3.right * horMovement;
        Vector3 vertVect = Vector3.up * vertMovement;
        Vector3 finalMove = vertVect + horVect;
        rB.AddForce(finalMove.normalized*speed);
    }
}
