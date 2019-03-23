using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.UI;
public class FuckupManager : MonoBehaviour
{

	public static readonly string[] unityLogs = new string[] {
		"Debug.Log(\"WHY ISNT IT WORKING GODDAMMIT\");",
		"Type \"UnityEngine.Camera\" does not contain a definition for \"cowabunga\"",
		"Debug.LogError(\"not enough money!\")",
		"You are trying to import an asset which contains a global asset manager",
		"UnassignedReferenceException: the variable DD of DDD is not assigned",
		"NullReferenceException",
		"The value that you want to instantiate was null",
		"The cake is a lie",
		"UnityException: Enum value not defined",
		"Invalid token \";\" in struct or class declaration",
		"Debug.Log(\"can you start working?\")",
		"Error: invalid token \"jak to jest być skrybą, dobrze?\" in class or struct declaration",
		"Error: Could not initialize Unity graphics",
		"OutOfMemoryException: why the hell are you programming in Java?",
		"Error CS8025: Parsing error",
		"Wstawaj Maciek, naruszyłeś pamięć"
	};


	public float debugLogTimer = 0f;
	public float min;
	public float max;
	public float fadeOutText;
	public float fadeOutTimer;

	public UnityEngine.UI.Text log;

    // Start is called before the first frame update
    void Start()
    {
        debugLogTimer = Random.Range(min, max);
    }

    // Update is called once per frame
    void Update()
    {
        if (debugLogTimer > 0f) {
        	debugLogTimer -= Time.deltaTime;
        }
        else {
        	LogFuckup();
        }

        if (fadeOutTimer > 0f) {
        	fadeOutTimer -= Time.deltaTime;
        } else {
        	FadeOutLog();
        }
    }

    void LogFuckup() {
    	log.gameObject.GetComponent<CanvasGroup>().alpha = 1f;
    	log.text = unityLogs[Random.Range(0, unityLogs.Length)];
    	debugLogTimer = Random.Range(min, max);
    	fadeOutTimer = 2.2f;
    }

    void FadeOutLog() {
    	log.gameObject.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(log.gameObject.GetComponent<CanvasGroup>().alpha, 0f, fadeOutText);
    }
}
