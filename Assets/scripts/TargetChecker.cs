using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // UI 네임스페이스 추가

public class TargetChecker : MonoBehaviour
{
    public List<string> correctOrderTags = new List<string> { "Disk1", "Disk2", "Disk3", "Disk4", "Disk5" };
    private int currentIndex = 0; // 현재 확인 중인 태그 인덱스

    // UI 텍스트 참조
    public TMP_Text debugText;

    void OnTriggerEnter(Collider other)
    {
   
        if (other.CompareTag(correctOrderTags[currentIndex]))
        {
            UpdateDebugText($"Disk{correctOrderTags[currentIndex]} has been placed correctly.");
            currentIndex++;

            if (currentIndex >= correctOrderTags.Count)
            {
                UpdateDebugText("Clear!!!");
                ClearLevel();
                FindObjectOfType<GameManager>().CompleteGame1();
            }
        }
        else
        {
            UpdateDebugText("Wrong disk. Please check the order again!");
        }
    }

    void UpdateDebugText(string message)
    {
        Debug.Log($"UI 업데이트 시도: {message}"); // 디버그 메시지 추가
        if (debugText != null)
        {
            debugText.text = message;
        }
        else
        {
            Debug.LogError("DebugText가 연결되지 않았습니다!");
        }
    }


    void ClearLevel()
    {
        UpdateDebugText("Level Cleared!");
    }
}
