using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Nekko.UI
{
    public class UIManager: MonoBehaviour
    {
        [SerializeField] private UIAssembler Assembler;

        [SerializeField] private UIDocument Document;
        [SerializeField] private Transform Canvas;
        
        private VisualElement _root;

        public void Build()
        {
            if (Document == null && Canvas == null) return;

            if (Document != null)
            {
                _root = new VisualElement
                {
                    name = "Root UI",
                    style =
                    {
                        width = Screen.width,
                        height = Screen.height,
                        flexDirection = FlexDirection.Row,
                        justifyContent = Justify.SpaceBetween,
                        alignItems = Align.Center
                    }
                };
            
                foreach (var group in Assembler.CurrentUI.Groups)
                {
                    var groupElement = new VisualElement
                    {
                        name = group.Name
                    };
                    foreach (var element in group.Elements)
                    {
                        element.Create(groupElement);
                    }
                    _root.Add(groupElement);
                }

                Document.rootVisualElement.Add(_root);
            }
            else
            {
                foreach (var group in Assembler.CurrentUI.Groups)
                {
                    var groupObj = new GameObject(group.Name, typeof(RectTransform))
                    {
                        transform = { parent = Canvas, localScale = Vector2.one },
                    };
                    var groupRect = groupObj.GetOrAddComponent<RectTransform>();
                    groupRect.anchoredPosition = Vector3.zero;
                    foreach (var element in group.Elements)
                    {
                        element.Create(groupObj.transform);
                    }
                }
            }
        }
    }
}