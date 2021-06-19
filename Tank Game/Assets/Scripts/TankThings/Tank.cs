using UnityEngine;
using TankGame.Profiles;
using UnityEngine.UI;
  
namespace TankGame
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Health))]
    public class Tank : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private bool randomize;

        [SerializeField]
        private GameManager gameManager;

        [SerializeField]
        private TankProfile tProfile;

        [SerializeField]
        private Weapon weapon;

        [SerializeField]
        private Image healthBar;

        private bool forward, backward;

        private Health health;
        private SpriteRenderer sRend;
        private Rigidbody2D rb;
        private TracksFade track;
        private Vector2 direction;
        #endregion Variables

        #region Unity Methods
        private void Awake()
        {
            health = GetComponent<Health>();
            sRend = GetComponent<SpriteRenderer>();
            rb = GetComponent<Rigidbody2D>();
            gameManager = FindObjectOfType<GameManager>();

            health.OnDamaged += UpdateHealthBar;
            health.OnDeath += gameManager.SpawnPlayer;
            sRend.flipY = true;
            rb.gravityScale = 0;
        }

        private void OnEnable()
        {
            InvokeRepeating(nameof(CreateTracks), tProfile.trackDelay, tProfile.trackDelay);

            if (randomize || tProfile == null)
            {
                tProfile = Randomizer.GetTankProfile();
                if (tProfile == null)
                {
                    Randomizer.ThrowError(gameObject.name);
                    return;
                }
            }

            InitializeTank();
            healthBar.fillAmount = 1;
        }

        private void OnDisable()
        {
            CancelInvoke();
        }

        private void Update()
        {
            HandleInput();
        }

        private void FixedUpdate()
        {
            CheckCollision();
            MoveTank();
        }
        #endregion Unity Methods

        #region Private Methods
        private void InitializeTank()
        {
            health.maxHealth = tProfile.health;
            sRend.sprite = tProfile.tankGraphic;
        }

        private void UpdateHealthBar()
        {
            if (healthBar != null)
                healthBar.fillAmount = health.currHealth / health.maxHealth;
        }

        private void HandleInput()
        {
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");

            if (forward)
            {
                direction.y = Mathf.Clamp(direction.y, -1, 0);
            }
            else if (backward)
            {
                direction.y = Mathf.Clamp(direction.y, 0, 1);
            }

            if (Input.GetButton("Fire1"))
                weapon.Shoot();
        }

        private void MoveTank()
        {
            if (direction.y != 0)
                rb.MovePosition(rb.position + (Vector2)transform.up * direction.y * tProfile.speed * Time.deltaTime);

            if (direction.x != 0)
                rb.MoveRotation(Mathf.LerpAngle(rb.rotation, rb.rotation + -direction.x * tProfile.turnSpeed, tProfile.turnSpeed * Time.deltaTime));
        }

        private void CreateTracks()
        {
            track = TracksPool.GetTrack();
            track.GetComponent<SpriteRenderer>().sprite = tProfile.trackGraphic;
            track.gameObject.SetActive(true);
            track.transform.position = transform.position;
            track.transform.rotation = transform.rotation;
        }

        private void CheckCollision()
        {
            if (Physics2D.CircleCast(rb.position, 0.7f, transform.up, 0.5f, LayerMask.GetMask("Environment")))
                forward = true;
            else
                forward = false;

            if (Physics2D.CircleCast(rb.position, 0.7f, -transform.up, 0.5f, LayerMask.GetMask("Environment")))
                backward = true;
            else
                backward = false;
        }
        #endregion Private Methods
    }
}