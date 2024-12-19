using UnityEngine;
using TMPro;

public class CarGameManager : MonoBehaviour
{
    public TMP_Text resultText; // Clear! 메시지를 표시할 UI 텍스트
    private string heaviestCarTag = "Car6"; // 가장 무거운 자동차의 태그

    public void OnCarButtonClicked(string carTag)
    {
        if (carTag == heaviestCarTag)
        {
            resultText.text = "Clear!"; // 정답일 때 메시지 표시
            Debug.Log("You guessed the heaviest car!");
            FindObjectOfType<GameManager>().CompleteGame2();
        }
        else
        {
            resultText.text = "Try Again!"; // 오답일 때 메시지 표시
            Debug.Log("Wrong car. Try again.");
        }
    }
}
