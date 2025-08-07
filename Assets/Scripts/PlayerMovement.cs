using UnityEngine;

public abstract class PlayerState
{
    public abstract void OnStart(PlayerMovement PM);
    public abstract void OnFixedUpdate(PlayerMovement PM);
    public abstract void OnEnd(PlayerMovement PM);
}

public class Player3DSub : PlayerState
{
    public override void OnStart(PlayerMovement PM)
    {
        PersistentVar.instance.FPCam.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public override void OnFixedUpdate(PlayerMovement PM)
    {
        float horMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");

        Vector3 horVect = PM.cam.transform.right * horMovement;
        Vector3 vertVect = GetCamFoward(PM.cam.transform.forward) * vertMovement;
        Vector3 finalMove = vertVect + horVect;
        PM.chCtr.Move(PM.PLAYER3DSPEED * Time.fixedDeltaTime * finalMove.normalized);

        Vector3 GetCamFoward(Vector3 baseForward)
        {
            return new Vector3(baseForward.x, 0, baseForward.z).normalized;
        }
    }
    public override void OnEnd(PlayerMovement PM)
    {
        PersistentVar.instance.FPCam.gameObject.SetActive(false);
    }
}

public class Sub2D : PlayerState
{
    public override void OnStart(PlayerMovement PM)
    {
        PersistentVar.instance.SubCam2D.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }
    public override void OnFixedUpdate(PlayerMovement PM)
    {
        float horMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");

        Vector3 horVect =  Vector3.right* horMovement;
        Vector3 vertVect = Vector3.up * vertMovement;
        Vector3 finalMove = vertVect + horVect;
        PM.rB.AddForce(finalMove.normalized * PM.SUB2DSPEED);
    }
    public override void OnEnd(PlayerMovement PM)
    {
        PersistentVar.instance.SubCam2D.gameObject.SetActive(false);
    }
}

public class Player2D : PlayerState
{
    public override void OnStart(PlayerMovement PM)
    {
        
    }
    public override void OnFixedUpdate(PlayerMovement PM)
    {

    }
    public override void OnEnd(PlayerMovement PM)
    {

    }
}
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public GameObject cam;
    [Header("PLAYER 3D VARIABLES")]
    [SerializeField] GameObject PlayerGO3D;
    [HideInInspector] public CharacterController chCtr;
    [SerializeField] public float PLAYER3DSPEED;
    
    [Header("PLAYER 2D VARIABLES")]
    [SerializeField] GameObject PlayerGO2D;

    [Header("SUB 2D VARIABLES")]
    [SerializeField] GameObject SubGO2D;
    [HideInInspector] public Rigidbody rB;
    [SerializeField] public float SUB2DSPEED;

    PlayerState CURRENSTATE;
    PlayerState PLAYER3DSTATE = new Player3DSub();
    PlayerState PLAYER2DSTATE = new Player2D();
    PlayerState SUB2DSTATE = new Sub2D();
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        rB = SubGO2D.GetComponent<Rigidbody>();
        chCtr = PlayerGO3D.GetComponent<CharacterController>();
        SwitchState(SUB2DSTATE);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SwitchState(PLAYER3DSTATE);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SwitchState(SUB2DSTATE);
        }
    }
    void FixedUpdate()
    {
        CURRENSTATE.OnFixedUpdate(this);
    }

    public void SwitchState(PlayerState newState)
    {
        if (CURRENSTATE != null)
            CURRENSTATE.OnEnd(this);

        CURRENSTATE = newState;
        CURRENSTATE.OnStart(this);
    }
}

