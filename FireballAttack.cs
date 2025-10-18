using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAttack : MonoBehaviour
{
    //The Fireball prefab and the Transform parameter of the attack point
    public GameObject fireballPrefab;
    public Transform attackPoint;
    public Camera playerCamera;


    void Update()
    {
        //If the player clicks the left mouse button, a fireball is created
        if (Input.GetMouseButtonDown(0))
        {
            ShootFireball();
        }
    }

    void ShootFireball()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Vector3 targetPoint = Physics.Raycast(ray, out RaycastHit hit) ? hit.point : ray.GetPoint(1000);

        GameObject fireball = Instantiate(
            fireballPrefab, 
            attackPoint.position, 
            Quaternion.LookRotation(targetPoint - attackPoint.position)
            );
    }
    
}