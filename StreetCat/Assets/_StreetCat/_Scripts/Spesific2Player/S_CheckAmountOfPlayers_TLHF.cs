using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class S_CheckAmountOfPlayers_TLHF : MonoBehaviour
{
    public int amountOfPlayers;

    [SerializeField]
    GameObject text1;
    [SerializeField]
    TextMeshProUGUI text2;

    [SerializeField]
    GameObject[] players;

    bool corutineStarted = true;


    public void RaiseAmount()
    {
        amountOfPlayers++;
    }

	private void Update()
	{

		if (amountOfPlayers == 2 && corutineStarted)
        {
            StartCoroutine(CountDown());
            corutineStarted = false;
        }
	}

    IEnumerator CountDown()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        float currentSpeed = players[0].transform.GetComponent<S_Movement_TF> ().speed;
        players[0].transform.GetComponent<S_Movement_TF>().speed = 0;
        players[1].transform.GetComponent<S_Movement_TF>().speed = 0;
        yield return new WaitForEndOfFrame();
        players[0].transform.position = new Vector3(-5, players[0].transform.position.y, players[0].transform.position.z);


		players[1].transform.position = new Vector3(5, players[1].transform.position.y, players[1].transform.position.z);


		text1.SetActive(false);
        text2.text = "3";
        yield return new WaitForSeconds(1);
		text2.text = "2";
		yield return new WaitForSeconds(1);
		text2.text = "1";
		yield return new WaitForSeconds(1);
        text2.text = "Start!!";
		players[0].transform.GetComponent<S_Movement_TF>().speed = currentSpeed;
		players[1].transform.GetComponent<S_Movement_TF>().speed = currentSpeed;
	}

}
