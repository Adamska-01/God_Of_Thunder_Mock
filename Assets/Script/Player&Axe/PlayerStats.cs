using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    //Respawn
    private Vector3 startPos;
    private float previousHealth;

    private float HealthValue;
    private float MagicValue;
    private int ScoreValue;
    private int JewelsValue;
    private int KeysValue;

    public int Damage;

    public Slider HealthBar;
    public Slider MagicBar;
    public Text Score;
    public Text Jewels;
    public Text Keys;
    public Image Item; private bool hasItem = false;
    
    private Animator myAnim;
    private bool isDead = false;

    //invincibility state
    private SpriteRenderer spRndrer;
    private float flashSpeed = 0.1f;
    private bool invincible;


    void Start()
    {
        HealthValue = 100f;
        HealthBar.maxValue = HealthValue;

        MagicValue = 0;
        MagicBar.maxValue = 100;

        ScoreValue = 0;
        Score.text = ScoreValue.ToString();

        JewelsValue = 0;
        Jewels.text = ScoreValue.ToString();

        KeysValue = 0;
        Keys.text = KeysValue.ToString();

        spRndrer = GetComponent<SpriteRenderer>();
        myAnim = GetComponent<Animator>();

        //for respawn
        SetPreviousPos(transform.position); SetPreviousHealth();
    }

    void Update()
    {
        updateUI();

        if (HealthValue <= 0)
        {
            myAnim.SetBool("isDead", true);
            isDead = true;
        }
        else
            isDead = false;
    }

    private void updateUI()
    {
        HealthValue = Mathf.Clamp(HealthValue, 0, HealthBar.maxValue);
        MagicValue = Mathf.Clamp(MagicValue, 0, MagicBar.maxValue);

        HealthBar.value = HealthValue;
        MagicBar.value = MagicValue;


        Score.text = ScoreValue.ToString();
        Jewels.text = JewelsValue.ToString();
        Keys.text = KeysValue.ToString();
    }

    //Getter and Setter

    public void TakeDamage(float damage)
    {
        if(!invincible && !isDead)
        {
            invincible = true;

            HealthValue -= damage;
            updateUI();

            StartCoroutine(Flash(flashSpeed));
        }
    }

    public void TakeDamageFromOther(float damage)
    {
        HealthValue -= damage; 
        updateUI();
    }

    public void Heal(float value)
    {
        HealthValue += value;
        updateUI();
    }

    public void TakeMagic(float value)
    {
        MagicValue += value;
        updateUI();
    }

    public void UseMagic(float value)
    {
        MagicValue -= value;
        updateUI();
    }

    public void TakeScore(int value)
    {
        ScoreValue += value;
        updateUI();
    }

    public void TakeJewels(int value)
    {
        JewelsValue += value;
        updateUI();
    }

    public void TakeKey(int value)
    {
        KeysValue += value;
        updateUI();
    }

    public void TakeSpecialItem(Sprite itemSprite)
    {
        Item.sprite = itemSprite;
        hasItem = true;
    }

    public void PayWithJewels(int value)
    {
        JewelsValue -= value;
        updateUI();
    }

    public void PayWithKeys(int value)
    {
        KeysValue -= value;
        updateUI();
    }

    public void SetIsDead(bool value)
    {
        isDead = value;

        myAnim.SetBool("isDead", value);
    }

    public void SetPreviousHealth()
    {
        previousHealth = HealthValue;
    }

    public void SetPreviousPos(Vector3 pos)
    {
        startPos = pos;
    }

    public int GetDamgeValue()
    {
        return Damage;
    }

    public float GetMagicValue()
    {
        return MagicValue;
    }

    public float GetHealthValue()
    {
        return HealthValue;
    }

    public int GetScoreValue()
    {
        return ScoreValue;
    }

    public int GetJewelsValue()
    {
        return JewelsValue;
    }

    public int GetKeysValue()
    {
        return KeysValue;
    }

    public bool IsDead()
    {
        return isDead;
    }

    public bool HasItem()
    {
        return hasItem;
    }

    public bool GetInvincible()
    {
        return invincible;
    }

    IEnumerator Flash(float x)
    {
        for (int i = 0; i < 10; i++)
        {
            spRndrer.enabled = false;
            yield return new WaitForSeconds(x);
            spRndrer.enabled = true;
            yield return new WaitForSeconds(x);
        }
        invincible = false;
    }

    public void Respawn()
    {
        SetIsDead(false);

        transform.position = startPos;

        HealthValue = previousHealth;
        updateUI();
    }
}
