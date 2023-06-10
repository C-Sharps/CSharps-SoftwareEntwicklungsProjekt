using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Code.Scripts.UI
{
    public class UITab : MonoBehaviour, IPointerClickHandler
    {
        public bool isActive = false;
        public GameObject activeImage;
        private Image _backgroundImage;
        
        private void Awake()
        {
            _backgroundImage = GetComponent<Image>();
            activeImage = transform.GetChild(1).gameObject;
        }

        public void ChangeTabState()
        {
            isActive = !isActive;

            _backgroundImage.color = !isActive ? new Color(59f / 255f, 59f / 255f, 59f / 255f) : new Color(50f / 255f, 50f / 255f, 50f / 255f);
            activeImage.SetActive(isActive);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            ChangeTabState();
        }
    }
}