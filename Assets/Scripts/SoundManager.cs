using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioSource audioSource; // ����� �ҽ�
    [SerializeField] private AudioClip displaySound;  
    [SerializeField] private AudioClip levelUpSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� ����
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ���� ��� �޼���
    public void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void PlayDisplaySound()
    {
        PlaySound(displaySound);
    }

    public void PlayLevelUpSound()
    {
        PlaySound(levelUpSound);
    }
}
