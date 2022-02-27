using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Vector3 _extraOffset;
    [SerializeField][Range(1f, 25f)] private float _followSpeed = 1f;

    [SerializeField] private Transform _player = null;
    [SerializeField] private Vector3 _minClampPos;
    [SerializeField] private Vector3 _maxClampPos;
    Vector3 _offsetPos;
    private void Start()
    {
        _offsetPos = transform.position - _player.position;
        Vector3 targetPos = new Vector3(_player.position.x + _extraOffset.x,
                                        _player.position.y + _offsetPos.y + _extraOffset.y,
                                        transform.position.z + _extraOffset.z);
        
        Debug.Log(targetPos);
        this.transform.position = targetPos;
    }
    private void FixedUpdate()
    {
        setCamPos();
    }

    private void setCamPos()
    {

        float xPos = _player.position.x; 
        Vector3 targetPos = new Vector3(Mathf.Clamp(xPos, _minClampPos.x, _maxClampPos.x),
                                        _player.position.y + _offsetPos.y + _extraOffset.y,
                                        transform.position.z + _extraOffset.z);
        this.transform.position = Vector3.Lerp(transform.position, targetPos, _followSpeed * Time.deltaTime);
    }
}
