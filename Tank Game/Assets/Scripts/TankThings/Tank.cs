using UnityEngine;
using TankGame.Profiles;
using UnityEngine.UI;
using TankGame.Managers;

namespace TankGame
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Health))]
    public class Tank : MonoBehaviour, IRandomizeAble
    {
        #region Variables
        public bool randomized;

        [SerializeField]
        private GameManager gameManager;

        public TankProfile tProfile;

        [SerializeField]
        private InputProfile iProfile;

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

        public void randomize()
        {
            randomized = true;
        }

        private void OnEnable()
        {
            InvokeRepeating(nameof(CreateTracks), tProfile.trackDelay, tProfile.trackDelay);

            if (randomized || tProfile == null)
            {
                tProfile = ProfilesManager.GetProfile(ProfilesManager.tankProfiles);
                if (tProfile == null)
                {
                    ProfilesManager.ThrowError(gameObject.name);
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
            Debug.Log("OBj: " + gameObject.name + " profile is: " + tProfile.name);
            sRend.sprite = tProfile.tankGraphic;
        }

        private void UpdateHealthBar()
        {
            if (healthBar != null)
                healthBar.fillAmount = health.currHealth / health.maxHealth;
        }

        private void HandleInput()
        {
            direction.x = Input.GetAxisRaw(iProfile.horizontalAxis);
            direction.y = Input.GetAxisRaw(iProfile.verticalAxis);

            if (forward)
            {
                direction.y = Mathf.Clamp(direction.y, -1, 0);
            }
            else if (backward)
            {
                direction.y = Mathf.Clamp(direction.y, 0, 1);
            }

            if (Input.GetButton(iProfile.shootButton))
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