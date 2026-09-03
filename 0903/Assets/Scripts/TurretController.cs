using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _muzzleTransform;
    
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _rotateSpeed;
    private float _detctionRange = 30;
    
    private float _coolDown = 1.5f;

    private float _timer;
    
    // 총알 소환
    // 총구 위치에
    
    private void Update()
    {
        _timer += Time.deltaTime;
        float distance = Vector3.Distance(transform.position,_playerTransform.position);
        
        if (distance <= _detctionRange)
        {
            LookAtPlayer();
            SpawnBullet();
        }
        else
        {
            RotateTurret();
        }
    }

    // (뜬금없지만) 플레이어가 특정 거리 밖에 있을땐 빙글빙글 돈다.
    // 일정 거리 내에 있을 때는 플레이어 응시한다.
    private void RotateTurret()
    {
        transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
    }

    private void LookAtPlayer()
    {
        transform.LookAt(_playerTransform);
    }

    private void SpawnBullet()
    {
        // 쿨타임. deeltaTime 누적.
        if (_coolDown >= _timer) return;
        
        GameObject bullet = Instantiate(_bulletPrefab);
        bullet.transform.position = _muzzleTransform.position;
        bullet.transform.rotation = _muzzleTransform.rotation;
        
        _timer = 0;
    }
    
    // 격발음
}
