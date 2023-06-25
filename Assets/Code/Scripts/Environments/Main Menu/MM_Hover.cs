using System;
using Code.Scripts.System.SaveLoad;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Scripts.Main_Menu
{
    public class MM_Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
    {
        private AudioSource _audioSource;
        private bool isOver = false;
        
        private void Awake()
        {
            if (_audioSource == null)
            {
                _audioSource = FindObjectOfType<SaveGameManager>().GetComponent<AudioSource>();
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.GetChild(0).transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
            isOver = true;
            if (_audioSource != null)
            {
                _audioSource.clip = Resources.Load<AudioClip>("SFX/UI/Modern2");
                _audioSource.Play();
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            isOver = false;
            transform.GetChild(0).transform.localScale = new Vector3(1f, 1f, 1f);
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            if (_audioSource != null && isOver)
            {
                _audioSource.clip = Resources.Load<AudioClip>("SFX/UI/Modern9");
                _audioSource.Play();
            }
        }
    }
}