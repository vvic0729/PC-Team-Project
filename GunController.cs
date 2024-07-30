using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;  // 총알 프리팹
    public Transform bulletSpawnPoint;  // 총알이 나갈 위치
    public float bulletSpeed = 5f;  // 총알 속도

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))  // 마우스 왼쪽 버튼 클릭
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // 총알 생성
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        // 총알에 힘을 가해 발사
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = bulletSpawnPoint.forward * bulletSpeed;
    }
}
