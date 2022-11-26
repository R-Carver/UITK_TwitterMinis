using UnityEngine.UIElements;
using UnityEngine;

namespace Flexbox_5min
{
    public class DemoRect : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<DemoRect> { }

        private const string styleResource = "Stylesheet_Flexbox";
        private const string ussContainer = "container";
        private const string ussElem = "elem";
        private const string ussLabel = "label";

        Label label1;

        public DemoRect()
        {
            styleSheets.Add(Resources.Load<StyleSheet>(styleResource));
            AddToClassList(ussContainer);

            VisualElement elem1 = new VisualElement();
            elem1.AddToClassList(ussElem);
            Add(elem1);

            label1 = new Label("test");
            label1.AddToClassList(ussLabel);
            elem1.Add(label1);

            elem1.RegisterCallback<GeometryChangedEvent>(OnResizeElem);
        }

        void OnResizeElem(GeometryChangedEvent evt)
        {
            label1.text = evt.newRect.width.ToString();
        }
    }
}


