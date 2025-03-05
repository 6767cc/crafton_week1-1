using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnCounting : MonoBehaviour
{
    //�̱�������
    public static TurnCounting Instance;

    public int turnCount = 0;
    public int limitTurn = 10;
    public int goalScore = 100;
    private int increaseMultiplier = 2;

    [SerializeField] private TextMeshProUGUI limitTurnText;
    [SerializeField] private TextMeshProUGUI goalScoreText;

    private void Awake()
    {
        // �̱��� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ���� �� �������� �ʵ��� ����
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject); // �ߺ� ����
        }

        updateText();
    }

    // ���� �ε�� �� ���� �ʱ�ȭ
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignUIElements(); // �ؽ�Ʈ�������� ��� �Ҵ�
        ResetVariables(); // ������ �⺻������ �ʱ�ȭ
        updateText();
    }

    // ���� �ʱ�ȭ �޼���
    private void ResetVariables()
    {
        turnCount = 0;
        limitTurn = 10;
        goalScore = 100;
        increaseMultiplier = 2;
    }

    private void AssignUIElements()
    {
        limitTurnText = GameObject.Find("TurnText")?.GetComponent<TextMeshProUGUI>();
        goalScoreText = GameObject.Find("GoalText")?.GetComponent<TextMeshProUGUI>();
    }

    public void checkTrunAndGoal()
    {
        updateText();

        if (turnCount >= limitTurn)
        {
            if(BoardCheck.score < goalScore)
            {
                //game over
                BoardCheck.gameover = true;
            }
            else
            {
                //����
                limitTurn += 10 * increaseMultiplier;
                goalScore += 100 * increaseMultiplier;
                increaseMultiplier += 1;
            }
        }
    }

    //�ؽ�Ʈ ����
    private void updateText()
    {
        limitTurnText.text = "Turn : " + turnCount + " / " + limitTurn;
        goalScoreText.text = "Goal : " + goalScore;
    }
}
