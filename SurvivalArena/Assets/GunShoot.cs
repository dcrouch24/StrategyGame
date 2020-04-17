using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public Camera cam;
    public GameObject hand;

    public float cooldown = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldown <= 0 && PlayerFinder.instance.player.gameObject.GetComponent<PlayerStats>().currentAmmo > 0)
        {
            PlayerFinder.instance.player.gameObject.GetComponent<PlayerStats>().currentAmmo -= 1;
            DoAttack();
        }
        cooldown -= Time.deltaTime;
    }

    private void DoAttack()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.Log("Shooting!");
        Debug.DrawLine(hand.transform.position, gameObject.transform.forward * 100, Color.magenta, 1f);

        if (Physics.Raycast(ray, out hit, 100f))
        {
            Debug.DrawLine(hand.transform.position, hit.point, Color.magenta, 1f);
            Debug.Log("Struck: " + hit.collider.gameObject.name);
            if (hit.collider.gameObject.tag == "Enemy")
            {
                Debug.Log("Hit with Gun!");
                hit.collider.gameObject.GetComponent<EnemyStats>().currentHealth -= 20;
                //hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 10, ForceMode.Impulse);
            }
        }
        else
        {
            Debug.Log("Miss with Gun!");
        }

        cooldown = 1f;
    }
}
