using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ComboManager : MonoBehaviour
{
    public GameObject health;
    public GameObject pointsManager;
    public GameObject timerObject;
    
    public Text firstButtonText;
    public Text secondButtonText;
    public Text thirdButtonText;
    
    private List<List<string>> _comboPermutations;
    private List<string> _actualCombo;
    private Queue<string> _input;
    private TimerStatus _timerStatus;

    // Start is called before the first frame update
    public void Start()
    {
        _timerStatus = timerObject.GetComponent<TimerStatus>();
        GenerateCombos();
        SetRandomCombo();
        Debug.Log(string.Join<string>(", ", _actualCombo));
    }

    public void Update()
    {
        firstButtonText.text = LastCharacter(_actualCombo[0]);
        secondButtonText.text = LastCharacter(_actualCombo[1]);
        thirdButtonText.text = LastCharacter(_actualCombo[2]);
    }

    private string LastCharacter(string str)
    {
        return str.Substring(str.Length - 1);
    }

    private void GenerateCombos()
    {
        _comboPermutations = new List<List<string>>();
        string[] arr = {"ButtonA", "ButtonB", "ButtonC"};
        // ReSharper disable once RedundantEnumerableCastCall
        _comboPermutations.Add(arr.OfType<string>().ToList());
        for (int i = 0; i <= 2; i++)
        {
            Swap(ref arr[0], ref arr[i]);
            // ReSharper disable once InvokeAsExtensionMethod
            _comboPermutations.Add(Enumerable.OfType<string>(arr).ToList());
            Swap(ref arr[0], ref arr[i]);
        }
    }

    private static void Swap(ref string a, ref string b)
    {
        var temp = a;
        a = b;
        b = temp;
    }

    private void SetRandomCombo()
    {
        _actualCombo = _comboPermutations[Random.Range(0, _comboPermutations.Count)];
    }

    private void ResetInput()
    {
        _input = new Queue<string>();
    }

    public void ClickButton(GameObject gameObj)
    {
        if (_input == null)
        {
            Debug.Log("input is not instantiated");
            ResetInput();
        }

        _input.Enqueue(gameObj.name);

        if (_input.Count != 3) return;
        Debug.Log("Finished: Calculate Result");
        CalculateResult();
    }

    private void CalculateResult()
    {
        if (Enumerable.SequenceEqual(_input, _actualCombo))
        {
            Debug.Log("Correcto perro");
            pointsManager.GetComponent<PointsStatus>().AddPoints(100);
        }
        else
        {
            Debug.Log("Quitale vida perro");
            health.GetComponent<Health>().RemoveLive();
        }

        _timerStatus.timeValue = 3;
        _timerStatus.ResetTimer();
        ResetInput();
    }
}