using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using UnityEngine.Rendering;

public class ThirdPersonShooterController1 : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform bulletProjectileMan = null;
    [SerializeField] private Transform spawnBulletPos;
    [SerializeField] public float offSet;
    [SerializeField] private Transform ptkcolor1;
    [SerializeField] private Transform ptkcolor2;
    [SerializeField] public int damage;
    RaycastHit raycastHit;
    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;
    public AttributesManager playerAtm;
    public AttributesManager enemyAtm;
    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }
    private void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;

        if (Physics.Raycast(ray, out raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        }
        if (starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
        }
        if (starterAssetsInputs.shoot)
        {

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    hit.collider.GetComponent<IDamageable>()?.TakeDamage(damage);
                }
            }

                if (hitTransform != null)
            {

                if (hitTransform.GetComponent<BulletTarget>() != null)
                {
                    Instantiate(ptkcolor1, raycastHit.point, Quaternion.identity);
                   
                    playerAtm.DealDamage(enemyAtm.gameObject);
                    
                }
                else
                {
                    Instantiate(ptkcolor2, raycastHit.point, Quaternion.identity);

                }
            }
            /* Vector3 aimDir = (mouseWorldPosition - spawnBulletPos.position).normalized;
             Instantiate(bulletProjectileMan, spawnBulletPos.position, Quaternion.LookRotation(aimDir, Vector3.up));*/
            
            starterAssetsInputs.shoot = false;
        }
        


    }
   
}
