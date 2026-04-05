using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip ShootingClip;
    [SerializeField] [Range (0,1)] float shootingVolume = 1f;
    [SerializeField] AudioClip DamageClip;
    [SerializeField] [Range (0,1)] float damageVolume = 1f;
    [SerializeField] AudioClip GameOver;
    [SerializeField] [Range ( 0,1)] float overVolume =1f;

    static AudioManager instance;

    void Awake(){
        ManageAudioSingleton();
    }

    void ManageAudioSingleton()
    {
        // int instanceCount = FindObjectsByType<AudioManager>(FindObjectsSortMode.None).Length;
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

    public void PlayShootingVFX()
    {
      PlayClip(ShootingClip, shootingVolume);
    }

    public void PlayDamageVFX()
    {  
         PlayClip(DamageClip, damageVolume);
    }

    public void GameOverVFX()
    {
        PlayClip(GameOver, overVolume);
    }
    
    void PlayClip(AudioClip clip, float volume)
    {
        if (clip!=null){
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }  
    }
}
