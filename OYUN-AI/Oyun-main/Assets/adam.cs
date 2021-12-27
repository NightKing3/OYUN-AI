using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class adam : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject hedef;

    public float menzil = 10f;
    
    

    void Start()
    {
       
        agent = GetComponent<NavMeshAgent>();
    }   
            
   
     private void Update()
    {
        float mesafe = Vector3.Distance(hedef.transform.position,transform.position);
        if (mesafe <= menzil  )
        {
            

                agent.SetDestination(hedef.transform.position);
                yontakip();

            
            
        }
        else
        {
            agent.SetDestination(transform.position);
        }
    }
   
    
    void yontakip()
    {
        Vector3 yon = (hedef.transform.position - transform.position).normalized;
        Quaternion takipet = Quaternion.LookRotation(new Vector3(yon.x,0f,yon.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, takipet, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, menzil);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HedefMermi"))
        {
            Destroy(gameObject);
        }
    }











}

