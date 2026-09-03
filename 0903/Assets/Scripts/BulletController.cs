using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _destroyTime;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = false;
        _audioSource.Stop();
        _audioSource.clip = _audioClip;
        _audioSource.Play();
        Destroy(gameObject, _destroyTime);
    }

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
    // 앞으로 나가는거
    // 시간 지나면 사라진다 (일정 거리 날아가면 사라진다)

    // 충돌체크
}
