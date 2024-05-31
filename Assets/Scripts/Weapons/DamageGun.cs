using System;
using UnityEngine;

public class DamageGun : MonoBehaviour
{
    
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 100f;
    [SerializeField] private AudioClip shootSound;
    private AudioSource _audioSource;
    public Transform PlayerCamera;

    private void Start()
    {
        PlayerCamera = PlayerCamera ? PlayerCamera : Camera.main.transform;
        _audioSource = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        _audioSource.PlayOneShot(shootSound);
        Ray gunRay = new Ray(PlayerCamera.position, PlayerCamera.forward);
        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, range))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.Health -= damage;
            }
        }
    }
}