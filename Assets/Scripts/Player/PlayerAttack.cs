using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private WeaponManager weaponManager;
    public float damage = 20f;

    private Animator zoomCameraAnim;
    private Animator zoomMainCameraAnim;
    private bool zoomed;
    private Camera mainCam;
    private GameObject crosshair;

    void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
        zoomCameraAnim = transform.Find(Tags.POV)
                                    .transform.Find(Tags.ZOOM_CAMERA).GetComponent<Animator>();
        zoomMainCameraAnim =  transform.Find(Tags.POV)
                                    .transform.Find(Tags.MAIN_CAMERA).GetComponent<Animator>();
        crosshair = GameObject.FindWithTag(Tags.CROSSHAIR);
        mainCam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponManager.GetCurrentWeapon() != null)
        {
            WeaponShoot();
            Zoom();
        }
    }

    void WeaponShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (weaponManager.GetCurrentWeapon().tag == Tags.AXE)
            {
                // AxeSwing();
            }
            if (weaponManager.GetCurrentWeapon().bulletType == WeaponBulletType.BULLET)
            {
                BulletFired();
            }
            
            weaponManager.GetCurrentWeapon().ShootAnimation();
        }
    }

    void Zoom()
    {
        if (weaponManager.GetCurrentWeapon().aimType == WeaponAimType.AIM)
        {
            if (Input.GetMouseButtonDown(1))
            {
                zoomCameraAnim.Play(AnimationTags.ZOOM_IN);
                zoomMainCameraAnim.Play(AnimationTags.ZOOM_IN);
                crosshair.SetActive(false);
            }

            if (Input.GetMouseButtonUp(1))
            {
                zoomCameraAnim.Play(AnimationTags.ZOOM_OUT);
                zoomMainCameraAnim.Play(AnimationTags.ZOOM_OUT);
                crosshair.SetActive(true);
            }
        }
    }

    void BulletFired()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit))
        {
            Debug.Log(hit.transform.gameObject.name);
        }
    }
}
