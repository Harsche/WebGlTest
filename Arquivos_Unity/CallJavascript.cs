using System.Globalization;
using System.Collections;
using UnityEngine;
using System.Runtime.InteropServices;
using TMPro;

public class CallJavascript : MonoBehaviour{
    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void HelloString(string str);

    [DllImport("__Internal")]
    private static extern void PrintFloatArray(float[] array, int size);

    [DllImport("__Internal")]
    private static extern int AddNumbers(int x, int y);

    [DllImport("__Internal")]
    private static extern string StringReturnValueFunction();

    [DllImport("__Internal")]
    private static extern void BindWebGLTexture(int texture);


    [SerializeField] private TextMeshProUGUI displayText;
    [SerializeField] private TextMeshProUGUI addValuesText;
    [SerializeField] private string message;
    [SerializeField] private string value;

    private int arraySize;
    private string helloString;
    private int num1;
    private int num2;

    [ContextMenu("SendMessage")]
    private void TestSendMessage(){
        gameObject.SendMessage(message, value);
    }

    public void DisplayString(string value){
        displayText.text = value;
    }
    
    public void AddValues(string numbersJson){
        float[] numbers = JsonUtility.FromJson<Numbers>(numbersJson).numbers;
        float result = 0f;
        foreach(float number in numbers){
        	result += number;
        }
        addValuesText.text = result.ToString(CultureInfo.InvariantCulture);
    }

    public void SetArraySize(string value){
        arraySize = int.Parse(value);
    }
    
    public void SetHelloString(string value){
        helloString = value;
    }
    
    public void SetNum1(string value){
        num1 = int.Parse(value);
    }
    
    public void SetNum2(string value){
        num2 = int.Parse(value);
    }
    
    // WebGL Methods

    public void WebHello(){
        Hello();
    }
    
    public void WebHelloString(){
        HelloString(helloString);
    }
    
    public void WebPrintFloatArray(){
        float[] myArray = new float[arraySize];
        PrintFloatArray(myArray, myArray.Length);
    }
    
    public void WebAddNumbers(){
        int result = AddNumbers(num1, num2);
        Debug.Log(result);
    }
}

public class Numbers
{
     public float[] numbers;
}