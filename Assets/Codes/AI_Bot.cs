using UnityEngine;
using UnityEngine.AI;

public class AI_Bot : MonoBehaviour
{
    NavMeshAgent navMesh;
    Transform target;
    [SerializeField] float lookDistance;

    public GameObject cubePrefab;
   
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();

        //target = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        ////Takip kodu
        //float playerDistance = Vector3.Distance(target.transform.position, transform.position);
        //if(playerDistance <= lookDistance)
        //{
        //    navMesh.SetDestination(target.position);
        //}

        //Karaktere bakma
        //transform.LookAt(target);
    }
    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            if(Input.GetMouseButtonDown(0))
            {
                navMesh.SetDestination(hit.point);
                GameObject createdCube = Instantiate(cubePrefab, hit.point, transform.rotation);
                Destroy(createdCube, 5f);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookDistance);
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<CharacterMovement>().health -= 30.0f;
        }
    }
}
