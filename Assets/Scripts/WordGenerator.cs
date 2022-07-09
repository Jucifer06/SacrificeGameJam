using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class WordGenerator : MonoBehaviour
{
    //public TextMeshProUGUI text;
    public GameObject movingText;
    public Canvas mainCanvas;

    // in seconds
    public float maxTimeBetweenWords = 5f;
    public float minTimeBetweenWords = 2f;
    public float timeFullSpeed = 60f;

    public float maxSpeedIncrease = 200f;
    public float currentSpeedIncrease = 0f;
    public float speedIncreasePerSecond;

    public float min_y = -170;
    public float max_y = 170;

    private float previousTime;
    private float delEachSecToTimeBetweenWords;
    public float currentTimeBetweenWords = 5f;
    private float timeBeforeNextWordLoad;

    private string[] words;

    void Start()
    {
        string wordString = "Able Back Bare Bass Blue Bold Busy Calm Cold Cool Damp Dark Dead Deaf Dear Deep Dual Dull Dumb Easy Evil Fair Fast Fine Firm Flat Fond Foul Free Full Glad Good Grey Grim Half Hard Head High Holy Huge Just Keen Kind Last Late Lazy Like Live Lone Long Loud Main Male Mass Mean Mere Mild Nazi Near Neat Next Nice Okay Only Open Oral Pale Past Pink Poor Pure Rare Real Rear Rich Rude Safe Same Sick Slim Slow Soft Sole Sore Sure Tall Then Thin Tidy Tiny Tory True Ugly Vain Vast Very Vice Warm Wary Weak Wide Wild Wise Zero Bear Beat Blow Burn Call Care Cast Come Cook Cope Cost Dare Deal Deny Draw Drop Earn Face Fail Fall Fear Feel Fill Find Form Gain Give Grow Hang Hate Have Head Hear Help Hide Hold Hope Hurt Join Jump Keep Kill Know Land Last Lead Lend Lift Like Link Live Look Lose Love Make Mark Meet Mind Miss Move Must Name Need Note Open Pass Pick Plan Play Pray Pull Push Read Rely Rest Ride Ring Rise Risk Roll Rule Save Seek Seem Sell Send Shed Show Shut Sign Sing Slip Sort Stay Step Stop Suit Take Talk Tell Tend Test Turn Vary View Vote Wait Wake Walk Want Warn Wash Wear Will Wish Work Area Army Baby Back Ball Band Bank Base Bill Body Book Call Card Care Case Cash City Club Cost Date Deal Door Duty East Edge Face Fact Farm Fear Fig File Film Fire Firm Fish Food Foot Form Fund Game Girl Goal Gold Hair Half Hall Hand Head Help Hill Home Hope Hour Idea Jack John Kind King Lack Lady Land Life Line List Look Lord Loss Love Mark Mary Mind Miss Move Name Need News Note Page Pain Pair Park Part Past Path Paul Plan Play Post Race Rain Rate Rest Rise Risk Road Rock Role Room Rule Sale Seat Shop Show Side Sign Site Size Skin Sort Star Step Task Team Term Test Text Time Tour Town Tree Turn Type Unit User View Wall Week West Wife Will Wind Wine Wood Word Work Year Abuse Adult Agent Anger Apple Award Basis Beach Birth Block Blood Board Brain Bread Break Brown Buyer Cause Chain Chair Chest Chief Child China Claim Class Clock Coach Coast Court Cover Cream Crime Cross Crowd Crown Cycle Dance Death Depth Doubt Draft Drama Dream Dress Drink Drive Earth Enemy Entry Error Event Faith Fault Field Fight Final Floor Focus Force Frame Frank Front Fruit Glass Grant Grass Green Group Guide Heart Henry Horse Hotel House Image Index Input Issue Japan Jones Judge Knife Laura Layer Level Lewis Light Limit Lunch Major March Match Metal Model Money Month Motor Mouth Music Night Noise North Novel Nurse Offer Order Other Owner Panel Paper Party Peace Peter Phase Phone Piece Pilot Pitch Place Plane Plant Plate Point Pound Power Press Price Pride Prize Proof Queen Radio Range Ratio Reply Right River Round Route Rugby Scale Scene Scope Score Sense Shape Share Sheep Sheet Shift Shirt Shock Sight Simon Skill Sleep Smile Smith Smoke Sound South Space Speed Spite Sport Squad Staff Stage Start State Steam Steel Stock Stone Store Study Stuff Style Sugar Table Taste Terry Theme Thing Title Total Touch Tower Track Trade Train Trend Trial Trust Truth Uncle Union Unity Value Video Visit Voice Waste Watch Water While White Whole Woman World Youth Admit Adopt Agree Allow Alter Apply Argue Arise Avoid Begin Blame Break Bring Build Burst Carry Catch Cause Check Claim Clean Clear Climb Close Count Cover Cross Dance Doubt Drink Drive Enjoy Enter Exist Fight Focus Force Guess Imply Issue Judge Laugh Learn Leave Limit Marry Match Occur Offer Order Phone Place Point Press Prove Raise Reach Refer Relax Serve Shall Share Shift Shoot Sleep Solve Sound Speak Spend Split Stand Start State Stick Study Teach Thank Think Throw Touch Train Treat Trust Visit Voice Waste Watch Worry Would Write Above Acute Alive Alone Angry Aware Awful Basic Black Blind Brave Brief Broad Brown Cheap Chief Civil Clean Clear Close Crazy Daily Dirty Early Empty Equal Exact Extra Faint False Fifth Final First Fresh Front Funny Giant Grand Great Green Gross Happy Harsh Heavy Human Ideal Inner Joint Large Legal Level Light Local Loose Lucky Magic Major Minor Moral Naked Nasty Naval Other Outer Plain Prime Prior Proud Quick Quiet Rapid Ready Right Roman Rough Round Royal Rural Sharp Sheer Short Silly Sixth Small Smart Solid Sorry Spare Steep Still Super Sweet Thick Third Tight Total Tough Upper Upset Urban Usual Vague Valid Vital White Whole Wrong Young";

        wordString = wordString.ToUpper();
        words = wordString.Split();

        currentTimeBetweenWords = maxTimeBetweenWords;
        timeBeforeNextWordLoad = 0;
        delEachSecToTimeBetweenWords = (maxTimeBetweenWords - minTimeBetweenWords) / timeFullSpeed;
        previousTime = Time.time;

        speedIncreasePerSecond = maxSpeedIncrease / timeFullSpeed;

        InvokeRepeating("IncreaseSpeed", 1f, 1f);

    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;
        float timeLapse = currentTime - previousTime;
        timeBeforeNextWordLoad -= timeLapse;

        if (timeBeforeNextWordLoad <= 0) {
            int index = Random.Range(0, words.Length);
            LoadWord(words[index]);

            if (currentTimeBetweenWords > minTimeBetweenWords)
            {
                currentTimeBetweenWords -= delEachSecToTimeBetweenWords;
            }
            timeBeforeNextWordLoad = currentTimeBetweenWords;
        }

        previousTime = currentTime;
    }

    private void IncreaseSpeed() {
        if (currentTimeBetweenWords > minTimeBetweenWords)
        {
            currentTimeBetweenWords -= delEachSecToTimeBetweenWords;
        }
        if (currentSpeedIncrease < maxSpeedIncrease) {
            currentSpeedIncrease += speedIncreasePerSecond;
        }
    }

    private void LoadWord(string word) {

        GameObject movingTextInstance = Instantiate(movingText);
        float y = Random.Range(min_y, max_y);
        movingTextInstance.transform.position += new Vector3(0, y, 0);

        movingTextInstance.transform.GetChild(1).gameObject.GetComponent<Text>().text = word;
        
        TextManager textManager = movingTextInstance.GetComponent<TextManager>();
        textManager.textSpeed_x += currentSpeedIncrease;
        movingTextInstance.transform.SetParent(mainCanvas.transform, false);
    }
}
