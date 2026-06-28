using UnityEngine;
namespace Project1
{
    public class GameManager : MonoBehaviour
    {
        public bool itsOnceDetect = false;
        [SerializeField] private PlayerMovement playerMovement;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void PlayerResetPositon()
        {
            playerMovement.ResetPositon();
            itsOnceDetect = false;
        }
    }
}
