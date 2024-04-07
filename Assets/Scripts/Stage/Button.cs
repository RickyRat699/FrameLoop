using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class Button : MonoBehaviour
{
    private BoxCollider _collider = null;
    [SerializeField, Tag ,Header("�{�^���������\��Tag")]
    private List<string> _tagList = new List<string>();
    [SerializeField,Tooltip("�����ꂽ�Ƃ��Ɉ�x���s���郁�\�b�h")]
    private UnityEvent _onClick = null;
    [SerializeField,Tooltip("������Ă���Ԏ��s���郁�\�b�h(FixedUpdate)")]
    private UnityEvent _onHold = null;
    [SerializeField,Tooltip("�������Ƃ��Ɏ��s���郁�\�b�h")]
    private UnityEvent _onRelease = null;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_tagList.Contains(other.tag))
        {
            return;
        }
        _onClick.Invoke();
    }
    private void OnTriggerStay(Collider other)
    {
        if (!_tagList.Contains(other.tag))
        {
            return;
        }

        _onHold.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_tagList.Contains(other.tag))
        {
            return;
        }

        _onRelease.Invoke();
    }
}
