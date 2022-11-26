using UnityEngine;
using UnityEngine.UIElements;

public class UI_old : MonoBehaviour
{
    public CubeController cube;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button buttonStart = root.Q<Button>("ButtonStart");
        Button buttonStop = root.Q<Button>("ButtonStop");
        Button buttonColor = root.Q<Button>("ButtonColor");

        buttonStart.clicked += () => cube.StartRotate();
        buttonStop.clicked += () => cube.StopRotate();
        buttonColor.clicked += () => cube.ChangeColor();
    }
}
