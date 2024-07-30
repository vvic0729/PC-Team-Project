using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;  // �Ѿ� ������
    public Transform bulletSpawnPoint;  // �Ѿ��� ���� ��ġ
    public float bulletSpeed = 5f;  // �Ѿ� �ӵ�

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))  // ���콺 ���� ��ư Ŭ��
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // �Ѿ� ����
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        // �Ѿ˿� ���� ���� �߻�
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = bulletSpawnPoint.forward * bulletSpeed;
    }
}
