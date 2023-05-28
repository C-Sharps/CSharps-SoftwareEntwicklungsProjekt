using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Scripts.Main_Menu
{
    public class MM_Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.GetChild(0).transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.GetChild(0).transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}