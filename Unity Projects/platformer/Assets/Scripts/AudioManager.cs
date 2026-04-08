using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip DeathClip;
    [SerializeField] AudioClip JumpClip;
    [SerializeField] AudioClip CoinClip;
    [SerializeField] [Range (0,1)] float ClipVolume =1f;

    static AudioManager instance;

      void Awake(){
        ManageAudioSingleton();
    }

    void ManageAudioSingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

     void PlayClip(AudioClip clip, float volume)
    {
        if (clip!=null){
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }  
    }

    public void PlayDeath()
    {
        PlayClip(DeathClip, ClipVolume);
    }

    public void PlayJump()
    {
        PlayClip(JumpClip, ClipVolume);
    }

    public void PlayCoin()
    {
        PlayClip(CoinClip, ClipVolume);
    }
}
