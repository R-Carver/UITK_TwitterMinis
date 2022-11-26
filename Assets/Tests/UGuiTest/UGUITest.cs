using UnityEngine;
using UnityEngine.UIElements;

public class UGUITest : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button testButton = root.Q<Button>("MyButton");
        testButton.clicked += () => { Debug.Log("Testbutton clicked"); };
    }
}
