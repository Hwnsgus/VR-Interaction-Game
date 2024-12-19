using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text allClearText;

    private bool isGame1Complete = false; // 원판 태그 순서 던지기
    private bool isGame2Complete = false; // 가장 무거운 자동차 맞히기
    private bool isGame3Complete = false; // 동물 오브젝트 없애기

    void Start()
    {
        if (allClearText != null)
            allClearText.gameObject.SetActive(false); // 초기 상태에서 비활성화
    }

    // 모든 게임이 끝났는지 확인하는 메서드
    private void CheckAllGamesComplete()
    {
        if (isGame1Complete && isGame2Complete && isGame3Complete)
        {
            ShowAllClearText();
        }
    }

    // "All Clear!" UI를 표시
    private void ShowAllClearText()
    {
        if (allClearText != null)
        {
            allClearText.gameObject.SetActive(true);
            allClearText.text = "All Clear!";
        }
    }

    // 각 게임 완료 상태를 업데이트하는 메서드
    public void CompleteGame1()
    {
        isGame1Complete = true;
        CheckAllGamesComplete();
    }

    public void CompleteGame2()
    {
        isGame2Complete = true;
        CheckAllGamesComplete();
    }

    public void CompleteGame3()
    {
        isGame3Complete = true;
        CheckAllGamesComplete();
    }
}
