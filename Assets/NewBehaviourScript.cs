using UnityEngine;
using UnityEngine.UI;

public class EnhancementSystem : MonoBehaviour
{
    // 초기 강화 성공 확률
    public float enhancementSuccessProbability = 50f;  // 첫 강화 확률 100%

    // 확률 감소율
    public float probabilityDecreaseRate = 5f;         // 매번 강화 시도 후 10% 감소

    // 최소 확률 (최소 5%까지는 성공 가능하도록 설정)
    public float minimumProbability = 5f;

    // 강화 성공 횟수 카운트
    private int successCount = 0;

    // 강화 성공 5회 시 바뀌는 이미지
    public Image 

    // 기본 이미지와 성공 후 이미지
    public Sprite defaultImage;
    public Sprite successImage;

    // 강화 결과를 보여줄 UI 텍스트
    public Text resultText;

    // 강화 버튼
    public Button enhanceButton;

    void Start()
    {
        // 기본 이미지를 설정
        enhancementImage.sprite = defaultImage;

        // 버튼에 강화 함수 연결
        enhanceButton.onClick.AddListener(OnEnhanceButtonClicked);
    }

    // 강화 버튼 클릭 시 실행되는 함수
    void OnEnhanceButtonClicked()
    {
        bool result = TryEnhance();
        resultText.text = "강화 결과: " + (result ? "성공" : "실패");

        // 강화가 성공할 때마다 성공 횟수 증가
        if (result)
        {
            successCount++;

            // 성공 횟수가 5번에 도달하면 이미지 변경
            if (successCount == 5)
            {
                ChangeImage();
            }
        }
    }

    // 강화 시도 함수
    bool TryEnhance()
    {
        // 0에서 100 사이의 랜덤 값 생성
        float randomValue = Random.Range(0f, 100f);

        // 강화 성공 여부 판단
        if (randomValue < enhancementSuccessProbability)
        {
            DecreaseEnhancementProbability();  // 강화 성공 후 확률 감소
            return true;  // 성공
        }
        else
        {
            return false;  // 실패
        }
    }

    // 강화 성공 확률 감소 함수
    void DecreaseEnhancementProbability()
    {
        // 강화 성공 확률을 감소시키되, 최소 확률 이하로는 떨어지지 않도록 설정
        enhancementSuccessProbability = Mathf.Max(enhancementSuccessProbability - probabilityDecreaseRate, minimumProbability);
    }

    // 5회 성공 시 이미지를 변경하는 함수
    void ChangeImage()
    {
        enhancementImage.sprite = successImage;
        Debug.Log("이미지가 변경되었습니다!");
    }
}
