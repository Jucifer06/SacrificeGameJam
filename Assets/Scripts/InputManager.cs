using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public InputField inputField;
    public float timeBetweenPenalities = 20f;
    public Text penalityText;
    public Text newRuleText;
    public int penalityMaxNumber = 3;

    public GameObject wordGenerator;

    private string penalityString = "";
    private int penalityNumber = 0;
    private List<char> usedChar = new List<char>();

    public AudioClip wrongClip;
    public AudioClip newRuleClip;
    private AudioSource sourceFX;

    private GameObject[] projectiles;

    void Start()
    {
        InvokeRepeating("Penality", timeBetweenPenalities, timeBetweenPenalities);
        projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        sourceFX = GameObject.FindGameObjectWithTag("SoundEffectAudioSource").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        projectiles = GameObject.FindGameObjectsWithTag("Projectile");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //inputField.Select();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            string text = inputField.text.ToUpper();
            int index = WordCorrect(text);
            if (index < 0)
            {
                sourceFX.PlayOneShot(wrongClip);
            }
            else
            {
                Destroy(projectiles[index].gameObject);
                StaticVariables.score += 1;
                // TODO : ANIMATION
            }

            inputField.text = "";
        }

        inputField.Select();
    }

    // Returns -1 if the word is incorrect, otherwise returns the index of the arrow to destroy
    private int WordCorrect(string t)
    {
        int index = -1;
        for (int i = 0; i < projectiles.Length; ++i)
        {
            string pText = projectiles[i].GetComponentInChildren<Text>().text;
            if (isCorrect(pText, t))
            {
                index = i;
            }
        }
        return index;
    }

    private bool isCorrect(string projectileText, string playerText)
    {
        List<(string, StaticVariables.RULE)> currentRules = StaticVariables.currentRules;
        string modifiedPorjectileText = string.Copy(projectileText);
        foreach ((string, StaticVariables.RULE) currentRule in currentRules)
        {
            modifiedPorjectileText = ApplyRule(modifiedPorjectileText, currentRule.Item2, currentRule.Item1);
        }
        return string.Equals(modifiedPorjectileText, playerText);
    }

    private string ApplyRule(string text, StaticVariables.RULE rule, string s)
    {

        string newText = string.Copy(text);

        if (rule == StaticVariables.RULE.typeTwice)
        {
            string newNewText = "";
            for (int i = 0; i < newText.Length; ++i)
            {
                newNewText += newText[i];
                if (newText[i] == s[0])
                {
                    newNewText += newText[i];
                }
            }
            newText = newNewText;
        }
        else if (rule == StaticVariables.RULE.dontType)
        {
            string newNewText = "";
            for (int i = 0; i < newText.Length; ++i)
            {
                if (newText[i] != s[0])
                {
                    newNewText += newText[i];
                }

            }
            newText = newNewText;
        }
        else if (rule == StaticVariables.RULE.reverse)
        {
            string newNewText = "";
            for (int i = newText.Length - 1; i >= 0; --i) {
                newNewText += newText[i];
            }

            newText = newNewText;
        }
        else if (rule == StaticVariables.RULE.writeLastFirst)
        {

            string newNewText = "";
            newNewText += newText[newText.Length - 1];
            Debug.Assert(newText.Length > 1);
            for (int i = 0; i < newText.Length-1; ++i)
            {
                newNewText += newText[i];
            }
            newText = newNewText.ToString();
        }
        else if (rule == StaticVariables.RULE.swap)
        {
            string newNewText = "";
            for (int i = 0; i < newText.Length; ++i)
            {
                if (newText[i] == s[0])
                {
                    newNewText += s[1];
                }
                else if (newText[i] == s[1])
                {
                    newNewText += s[0];
                }
                else
                {
                    newNewText += newText[i];
                }

            }
            newText = newNewText;
        }

        return newText;
    }

    private void Penality()
    {
        if (penalityNumber > penalityMaxNumber-1)
        {
            return;
        }
        else if (penalityNumber < 2)
        {

            char c1;
            do
            {
                c1 = StaticVariables.commonLetters[Random.Range(0, StaticVariables.commonLetters.Length - 1)];
            } while (usedChar.Contains(c1));
            usedChar.Add(c1);

            if (penalityNumber == 0)
            {
                StaticVariables.currentRules.Add((c1.ToString(), StaticVariables.RULE.typeTwice));
                penalityString += " 1. Type twice the letter " + c1.ToString().ToUpper();
            }
            else if (penalityNumber == 1)
            {
                StaticVariables.currentRules.Add((c1.ToString(), StaticVariables.RULE.dontType));
                penalityString += "\n 2. Skip the letter " + c1.ToString().ToUpper();
            }
        }
        else if (penalityNumber == 2)
        {
            WordGenerator wg = wordGenerator.GetComponent<WordGenerator>();
            wg.currentSpeedIncrease = 0f;
            wg.currentTimeBetweenWords = 5f;

            int r = Random.Range(1, 3);
            if (r == 1)
            {
                StaticVariables.currentRules.Add((" ", StaticVariables.RULE.reverse));
                penalityString += "\n 3. Reverse the order the the word";
            }
            else if (r == 2)
            {
                StaticVariables.currentRules.Add((" ", StaticVariables.RULE.writeLastFirst));
                penalityString += "\n 3. Write the last letter first";
            }
            else if (r == 3)
            {
                char c1;
                do
                {
                    c1 = StaticVariables.commonLetters[Random.Range(0, StaticVariables.commonLetters.Length - 1)];
                } while (usedChar.Contains(c1));
                usedChar.Add(c1);
                char c2;
                do
                {
                    c2 = StaticVariables.commonLetters[Random.Range(0, StaticVariables.commonLetters.Length - 1)];
                } while (usedChar.Contains(c2));
                usedChar.Add(c2);
                StaticVariables.currentRules.Add((c1.ToString() + c2.ToString(), StaticVariables.RULE.swap));
                penalityString += "\n 3. Swap letters " + c1.ToString() + " and " + c2.ToString();
            }

        }

        NewRule();
        penalityNumber += 1;
        penalityText.text = penalityString;
    }

    private void NewRule() {

        newRuleText.GetComponent<Animator>().Play("newRule", -1, 0);
        sourceFX.PlayOneShot(newRuleClip);
        projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject projectile in projectiles) {
            Destroy(projectile.gameObject);
        }
    }
}
