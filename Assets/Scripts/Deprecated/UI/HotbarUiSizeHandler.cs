// using UnityEngine;
// using UnityEngine.UI;
//
// namespace UI
// {
//     [RequireComponent(typeof(GridLayoutGroup))]
//
//     public class HotbarUiSizeHandler : MonoBehaviour
//     {
//         [SerializeField] private HotbarQuantityHandler hotbarQuantityHandler;
//     
//         private GridLayoutGroup _gridLayoutGroup;
//         private RectTransform _rectTransform;
//
//         private Vector2 _sizeDelta;
//         private Vector2 _cellSize;
//         private void Start()
//         {
//             //hotbarQuantityHandler = GetComponent<HotbarQuantityHandler>();
//             _gridLayoutGroup = GetComponent<GridLayoutGroup>();
//             _rectTransform = GetComponent<RectTransform>();
//             _cellSize = _gridLayoutGroup.cellSize;
//             _sizeDelta = _rectTransform.sizeDelta;
//
//         }
//
//         private void OnEnable()
//         {
//             hotbarQuantityHandler.QuantityChangedEvent += OnHotbarCapacityChanged;
//         }
//
//         private void OnDisable()
//         {
//             hotbarQuantityHandler.QuantityChangedEvent -= OnHotbarCapacityChanged;
//         }
//
//         void OnHotbarCapacityChanged(int quantity)
//         {
//             _rectTransform.sizeDelta = new Vector2(_cellSize.x * quantity, _cellSize.y);
//
//         }
//     }
// }