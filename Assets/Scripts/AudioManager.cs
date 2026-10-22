using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource effects;
    [SerializeField] private AudioSource bg;
    [SerializeField] private AudioClip shoot;
    [SerializeField] private AudioClip audiences;


    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }

    }
    private void Start()
    {
        bg.clip = audiences;
        bg.Play();
    }
    public void playShoot()
    {
        effects.PlayOneShot(shoot);
    }
           

    public void playAudiences()
    {
        bg.PlayOneShot(audiences);
    }
}
