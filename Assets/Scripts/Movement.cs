using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using System.Collections;


public class Movement : MonoBehaviour
{

    private RectTransform rt;
    private RectTransform cRT;
    private Rigidbody2D rb;
    public Vector2 moveDirection;
    public int healthPoint = 100;
    public int maxHealth = 100;
    public int damage;
    public float baseSpeed = 5;
    private float speed;
    public float vertical;
    public float fireRate;
    public float fireSpeed;
    public float chargeRate;
    private float percent;
    public float sRate;
    public float baseRate;
    private float dashTimer = 1;
    public float dashRate = 2;
    public float dashAmount = 20;
    public Animator animator;
    public Transform childObject;
    private bool facingRight;
    public SpriteRenderer sprite;
    public cycle cycle;
    public Weopons weopons;
    public bool allowMove;
    public bool allowDash;
    public bool basic = true;
    public bool heavy;
    public bool light;
    public bool iFrame;
    public GameObject projectile;
    public GameObject projectileBase;
    public GameObject projectileS;
    public GameObject projectileB;
    public GameObject healthBar;
    public GameObject chargeBar;
    public GameObject dashTracker;
    public GameObject failureMenu;
    public TextMeshProUGUI health;
    public TextMeshProUGUI charge;
    public AudioSource audioBaseSource;
    public AudioSource audioRailSource;
    public AudioSource audioRailShootSource;
    public AudioSource audioWaveComplete;
    public AudioClip[] audioClips;
    public string respawn;
    private bool audioBasePlayThrough = false;
    private bool audioRailPlayThrough = false;

    void Start()
    {
        cycle = FindFirstObjectByType<cycle>();
        rt = healthBar.GetComponent<RectTransform>();
        cRT = chargeBar.GetComponent<RectTransform>();
        projectile = projectileBase.gameObject;
        allowMove = true;
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        speed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoint > maxHealth)
        {
            healthPoint = maxHealth;
        }
        if (healthPoint <= 0)
        {
            allowMove = false;
            failureMenu.SetActive(true);
            Time.timeScale = 0;

        }
        health.text = healthPoint.ToString();
        percent = (chargeRate / fireSpeed)*100;
        charge.text = percent.ToString("F0");
        rt.offsetMax = new Vector2(-(1920 - healthPoint * 4.2f), 0);
        cRT.offsetMax = new Vector2(-(1920 - chargeRate * (420/fireSpeed)),-1000);
        fireRate -= Time.deltaTime;
        if (allowMove)
        {
            if(cycle.availableWeopons[cycle.currentIndex].firingType != Weopons.styles.hold)
            {
                chargeBar.gameObject.SetActive(false);
            }
            if (cycle.availableWeopons[cycle.currentIndex].firingType == Weopons.styles.tap)
            {
                if (Input.GetButton("Fire") && fireRate <= 0)
                {
                    Vector2 ship = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                    Instantiate(projectile, ship, Quaternion.identity);
                    fireRate = fireSpeed;
                    if (audioBasePlayThrough) {
                        audioBasePlayThrough = false;
                    }

                    if (projectile = projectileBase.gameObject) {
                        audioBaseSource.clip = audioClips[0];
                        if (!audioBaseSource.isPlaying && !audioBasePlayThrough) {
                            audioBaseSource.UnPause();
                            if (!audioBaseSource.isPlaying) {
                                audioBaseSource.Play();
                                StartCoroutine(TrackAudioCompletion(audioBaseSource, audioBasePlayThrough));
                            }
                        }

                    }
                }

                if (!Input.GetButton("Fire")) {
                    if (audioBaseSource.isPlaying)
                    {
                        audioBaseSource.Pause();
                    }
                }
            }
            else if (cycle.availableWeopons[cycle.currentIndex].firingType == Weopons.styles.hold)
            {
                if (chargeBar.activeInHierarchy == false)
                {
                    chargeBar.gameObject.SetActive(true);
                }
                if (Input.GetButton("Fire"))
                {
                    audioRailSource.clip = audioClips[1];
                    if (chargeRate < fireSpeed){ 
                        chargeRate += Time.deltaTime;

                        if (!audioRailSource.isPlaying && !audioRailPlayThrough)
                        {
                            audioRailSource.UnPause();
                            if (!audioRailSource.isPlaying)
                            {
                                audioRailSource.Play();
                                StartCoroutine(TrackAudioCompletion(audioRailSource, audioRailPlayThrough));
                            }
                        }
                    }
                }

                if (!Input.GetButton("Fire"))
                {
                    if (audioRailSource.isPlaying)
                    {
                        audioRailSource.Pause();
                    }
                }

                if (chargeRate >= fireSpeed && Input.GetButtonUp("Fire"))
                {
                    Vector2 ship = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                    Instantiate(projectile, ship, Quaternion.identity);
                    fireRate = fireSpeed;
                    chargeRate = 0;
                }
            }

        
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveDirection.x * speed, rb.linearVelocity.y);
        moveDirection.y = Input.GetAxisRaw("Vertical");
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, moveDirection.y * speed);

    }else if (!allowMove)
        {
            moveDirection.x = 0;
            rb.linearVelocity = Vector2.zero;
        }
        if (moveDirection.x < 0 && facingRight)
        {
            facingRight = !facingRight;
            sprite.flipX = true;
        }
        else if (moveDirection.x > 0 && !facingRight)
        {
            facingRight = !facingRight;
            sprite.flipX = false;
        }

        //if (animator)
        //{
        //    animator.SetFloat("speed", Mathf.Abs(moveDirection.x));
        //}
    }

    private IEnumerator TrackAudioCompletion(AudioSource source, bool playthrough) {
        while (source.isPlaying) { 
            yield return null;
        }
        playthrough = true;
    }

    public void Burst()
    {
        projectile = projectileS.gameObject;
        fireSpeed = sRate;
    }

    public void Base()
    {
        projectile = projectileBase.gameObject;
        fireSpeed = baseRate;
    }
    public void Boom()
    {
        projectile = projectileB.gameObject;
        fireSpeed = sRate * 2;
    }
    public void heavyBody()
    {
        basic = false;
        heavy = true;
        light = false;
        maxHealth = 200;
        speed = baseSpeed * 0.5f;
    }
    public void basicBody()
    {
        basic = true;
        heavy = false;
        light = false;
        maxHealth = 100;
        speed = baseSpeed * 1f;
    }
    public void lightBody()
    {
        basic = false;
        heavy = false;
        light = true;
        maxHealth = 50;
        speed = baseSpeed * 2f;
    }

}

