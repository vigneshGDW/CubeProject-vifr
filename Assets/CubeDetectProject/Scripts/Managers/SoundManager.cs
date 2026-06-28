using UnityEngine;
namespace Project1
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip[] audioClips;
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
        public void PlaySound(int index)
        {
            if (index >= 0 && index < audioClips.Length)
            {
                audioSource.PlayOneShot(audioClips[index]);
            }
        }
    }
}
