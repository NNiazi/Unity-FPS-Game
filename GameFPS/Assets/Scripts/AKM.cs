using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AKM : MonoBehaviour {
   
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public int bulletsPerMag = 9; //Bullets in each magazine
    public int bulletsTotal = 100; //Total bullets that we have

    public int currentBullets; //Current bullets in magazine

    private bool isReloading;

    public Camera fpsCam;
    public Text ammoCountUI;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private Animator anim;
    private AudioSource mAudioSrc;

    void Start() {

        mAudioSrc = GetComponent<AudioSource>();

        anim = GetComponent<Animator>();
        currentBullets = bulletsPerMag;
        GameManager.Instance.GameOverEvent += GameOverEvent;
    }

    private void GameOverEvent(object sender, System.EventArgs e)
    {

        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("Fire1"))
        {

            if (currentBullets > 0)
                //mAudioSrc.Play();
                Shoot();
            else
                StartReload();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentBullets < bulletsPerMag && bulletsTotal > 0)
            StartReload();
        }

    }

    void FixedUpdate() {

        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);

        isReloading = info.IsName("Reload");
    }

    void Shoot() {

        if (currentBullets <= 0 || isReloading)
            return; 


        RaycastHit hit;

       if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.Damage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }

        anim.CrossFadeInFixedTime("Fire", 0.01f);
        muzzleFlash.Play();
        mAudioSrc.Play();

        currentBullets--;
        UpdateAmmoUIText();
    }

    public void Reload() {

        if (bulletsTotal <= 0) return;

        int bulletsToLoad = bulletsPerMag - currentBullets;

        //Smart "if' statement
        int bulletsToDetuct = (bulletsTotal >= bulletsToLoad) ? bulletsToLoad : bulletsTotal;

        bulletsTotal -= bulletsToDetuct;
        currentBullets += bulletsToDetuct;

        UpdateAmmoUIText();
    }

    private void StartReload() {

        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);

        if (isReloading) return;

        anim.CrossFadeInFixedTime("Reload", 0.01f);
    }

    private void UpdateAmmoUIText () {

        ammoCountUI.text = currentBullets + " /" + bulletsTotal;
    }
}