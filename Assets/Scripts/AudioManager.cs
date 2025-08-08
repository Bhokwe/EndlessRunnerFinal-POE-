using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    void Start()
    {
        foreach(Sound s in sounds) //main theme to loop
        {
            s.source= gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
        PlaySound("Main Theme");

        PlaySound("MainClick");
    }

    public void PlaySound(string name)
    {
        foreach (Sound s in sounds)
        {

            if (s.name == name)
                s.source.Play();
        }


    }
}
