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
            UpdateDebugText($"원판 {correctOrderTags[currentIndex]} 이(가) 올바른 위치에 들어갔습니다.");
            currentIndex++;

            if (currentIndex >= correctOrderTags.Count)
            {
                UpdateDebugText("클리어! 모든 원판이 올바른 순서로 들어갔습니다.");
                ClearLevel();
            }
        }
        else
        {
            UpdateDebugText("잘못된 원판입니다. 순서를 다시 확인하세요!");
        }
    }

    void UpdateDebugText(string message)
    {
        // UI 텍스트에 메시지 표시
        if (debugText != null)
        {
            debugText.text = message;
        }
    }

    void ClearLevel()
    {
        UpdateDebugText("게임 클리어!");
    }
}
