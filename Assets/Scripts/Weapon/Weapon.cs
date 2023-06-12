using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    private Camera playerCamera;

    [Header("Weapon Stats")]
    [SerializeField] private bool isSingleFire;
    [SerializeField] private float attackRange;
    [SerializeField] private float damage;
    [SerializeField] private float fireRate;
    [SerializeField] private LayerMask layerMask;

    [Header("Sfx")]
    [SerializeField] private AudioClip fire;
    [SerializeField] private AudioClip reload;

    [HideInInspector] public bool isFiring;
    private bool readyToUse = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        playerCamera = GetComponentInParent<Camera>();
    }

    private void OnEnable()
    {
        GetComponentInParent<PlayerAnimationController>().animator = animator;
    }

    public void Attack()
    {
        // If ready to use, attack
        if(readyToUse)
        {
            isFiring = true;

            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, attackRange, layerMask))
            {
                Debug.Log(hitInfo.collider.name);
                // Deal Damage here...
            }

            // Play Animation & sfx
            animator.PlayInFixedTime("Fire", 0, fireRate);
            audioSource.clip = fire;
            audioSource.Play();

            // Wait for some time, cannot fire again until it is ready (FireRate)
            readyToUse = false;
            StartCoroutine(WeaponUsed());
        }
    }

    public void Reload()
    {
        // Play Animation & sfx
        animator.Play("Reload");
        audioSource.PlayOneShot(reload);
    }

    IEnumerator WeaponUsed()
    {
        yield return new WaitForSeconds(fireRate);
        readyToUse = true;
        
        if (isFiring && !isSingleFire)
            Attack();
    }
}
