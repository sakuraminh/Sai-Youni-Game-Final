using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManage : MSingleton<AudioManage>
{
    [SerializeField] protected AudioSource music;
    public AudioSource Music => this.music;

    [SerializeField] protected AudioSource sFX;
    public AudioSource SFX => this.sFX;

    [Header("Backgroud")]
    public AudioClip Backgroud;

    [Header("Player")]
    public AudioClip playerHit;
    public AudioClip playerDie;
    public AudioClip playerRun;
    public AudioClip playerFIreReady;
    public AudioClip playerFireFly;
    public AudioClip playerFireHit;


    [Header("Enemy")]

    public AudioClip enemyHit;
    public AudioClip enemyAttack;
    public AudioClip enemyDie;

    protected override void Start()
    {
        base.Start();
        music.clip = Backgroud;
        music.Play();
    }

    public virtual void PlaySFX(AudioClip clip)
    {
        sFX.PlayOneShot(clip);
        //Debug.Log("PlaySFX: " + clip.name);
    }
}
