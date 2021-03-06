﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KagerouCutController : MonoBehaviour {
    
    [SerializeField]
    private Sprite[] characterSprites; 
    
    [SerializeField]
    private Sprite[] furballSprites;

    [SerializeField]
    private int furballCount = 0;
   
    [SerializeField]
    private KagCutCharacter characterPrefab;
    [SerializeField] 
    private RazorController razor;
    [SerializeField]
    private GameObject background;

    [SerializeField]
    private float furspeed = 0.01f;

    private float furDistance = 1.2f;
    private GameObject[] furballs;
	
    // Use this for initialization
	void Start () {
        furballs = new GameObject[furballCount];
        // Set the sprites
        int randChar = Random.Range(0, characterSprites.Length);
        Sprite charSprite = characterSprites[randChar];
        Sprite furSprite = furballSprites[randChar];
	    KagCutCharacter character = Instantiate(characterPrefab);
        character.GetComponent<SpriteRenderer>().sprite = charSprite; 
        GameObject furball = character.transform.Find("FurBall").gameObject;
        GameObject spriteObj = furball.transform.Find("Sprite").gameObject;
        spriteObj.GetComponent<SpriteRenderer>().sprite = furSprite; 
        
        float angle = 0.4f;
        float[] angles= new float[furballCount];
        for (int i=0; i<furballCount; i++){
            angle = Random.Range(angle-0.5f, angle-Mathf.PI/furballCount-0.2f);
            angles[i] = angle;
        }
        float center_shift = angles[0] + angles[furballCount-1] + Mathf.PI;
        for (int i=0; i<furballCount; i++){
            angles[i] -= center_shift;
        }

        for (int i=0; i<furballCount; i++){
            angle = angles[i];
            float x = razor.transform.position.x + furDistance * Mathf.Cos(angle);
            float y = razor.transform.position.y + furDistance * Mathf.Sin(angle);
            GameObject newFur = Instantiate(furball, new Vector3(x, y, 0), Quaternion.identity);
            FurBallController s = newFur.GetComponent<FurBallController>();
            s.speed = furspeed;
            newFur.GetComponent<Animator>().SetFloat("offset", Random.Range(0f, 1f));
            furballs[i] = newFur;
        }
        furball.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		bool ballsLeft = false;
        foreach (GameObject ball in furballs){
            if (ball != null){
                ballsLeft = true;
                break;
            }
        }
        if (!ballsLeft) {
            background.GetComponent<Animator>().SetTrigger("Win");
            MicrogameController.instance.setVictory(victory: true, final: true);
        }
	}
}
