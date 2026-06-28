using UnityEngine;
namespace Project1
{
    public class GameManager : MonoBehaviour
    {
        public bool itsOnceDetect = false;//Check if the cube is detected once
        [SerializeField] private PlayerMovement playerMovement;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);//Dont reload this object when scene change
        }
        //Reset Player Position
        public void PlayerResetPositon()
        {
            playerMovement.ResetPositon();
            itsOnceDetect = false;
        }
    }
}
