using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mancınık : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject hedef;

    public float menzil = 10f;

    public GameObject Mermi;
    public GameObject firePoint;
    private float firecountdown = 2f;
    public float firerate = 1f;

    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        if (hedef != null)
        {
            float mesafe = Vector3.Distance(hedef.transform.position, transform.position);
            if (mesafe <= menzil)
            {
                agent.SetDestination(transform.position);
                yontakip();
                if (firecountdown <= 0f)
                {
                    ateset();

                    firecountdown = 1f / firerate;
                }

                firecountdown -= Time.deltaTime;


            }
        }
    }
    void ateset()
    {
        GameObject mermim = Instantiate(Mermi, firePoint.transform.position, firePoint.transform.rotation);

        mermim.GetComponent<Rigidbody>().AddForce(transform.forward * Time.deltaTime * 3000f, ForceMode.Impulse);
    }

    void yontakip()
    {
        Vector3 yon = (hedef.transform.position - transform.position).normalized;
        Quaternion takipet = Quaternion.LookRotation(new Vector3(yon.x, 0f, yon.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, takipet, Time.deltaTime * 6000f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, menzil);
    }

    
}