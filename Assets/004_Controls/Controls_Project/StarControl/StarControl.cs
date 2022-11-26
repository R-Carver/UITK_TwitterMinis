using UnityEngine.UIElements;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace CustomControls
{
    public class StarControl : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<StarControl, UxmlTraits> { }

        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            UxmlIntAttributeDescription m_StarAttribute = new UxmlIntAttributeDescription()
            {
                name = "stars"
            };

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);

                (ve as StarControl).stars = m_StarAttribute.GetValueFromBag(bag, cc);
            }
        }

        int m_Stars;

        public int stars
        {
            get => m_Stars;
            set
            {
                m_Stars = value;
                SetStars();
                MarkDirtyRepaint();
            }
        }


        private const string styleResource = "StarControl_Stylesheet";
        private const string ussContainer = "container";
        private const string ussOuterStar = "outerStar";
        private const string ussInnerStar = "innerStar";

        List<VisualElement> outerStars = new List<VisualElement>();
        List<VisualElement> innerStars = new List<VisualElement>();

        public StarControl()
        {
            styleSheets.Add(Resources.Load<StyleSheet>(styleResource));

            VisualElement container = new VisualElement();
            container.name = "container";
            container.AddToClassList(ussContainer);
            
            hierarchy.Add(container);

            for(int i=0; i<7; i++)
            {
                VisualElement outerStarTemp = new VisualElement();
                outerStarTemp.name = "outerStar" + i;
                outerStarTemp.AddToClassList(ussOuterStar);
                container.Add(outerStarTemp);

                outerStars.Add(outerStarTemp);

                VisualElement innerStarTemp = new VisualElement();
                innerStarTemp.name = "innerStar" + i;
                innerStarTemp.AddToClassList(ussInnerStar);
                outerStarTemp.Add(innerStarTemp);

                innerStars.Add(innerStarTemp);
            }

            stars = 0;
        }

        private void SetStars()
        {
            HideAllStars();
            innerStars.Take(m_Stars).ToList().ForEach((elem) => elem.style.visibility = Visibility.Visible);
        }

        private void HideAllStars()
        {
            innerStars.ForEach((elem) => elem.style.visibility = Visibility.Hidden);
        }
    }
}


