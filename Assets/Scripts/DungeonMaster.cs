using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System;

public class DungeonMaster : MonoBehaviour {

    XmlDocument xmlDoc;
    public CamRot cameraRotation;
    public EnemySpawner enemySpawner;

	// Use this for initialization
	void Start () {
        xmlDoc = new XmlDocument();
        string directory = Directory.GetCurrentDirectory() + @"\Assets\Scripts\demostage.xml";
        xmlDoc.Load(directory);
        StartCoroutine(NextEvent(0));
	}
	
	// Update is called once per frame
	IEnumerator NextEvent(int bookmark) {

        yield return new WaitForSeconds(2);

        while(bookmark < xmlDoc.DocumentElement.ChildNodes.Count)
        {
            XmlNode currentEvent = xmlDoc.DocumentElement.ChildNodes[bookmark];
            string currentEventType = currentEvent.ChildNodes[0].InnerText;
            float nextEvent = 0;

            switch (currentEventType)
            {
                case "rotate":
                    float rotAmount = Single.Parse(currentEvent.ChildNodes[1].InnerText);
                    float rotIncrement = Single.Parse(currentEvent.ChildNodes[2].InnerText);
                    cameraRotation.changeCameraAngle(rotAmount, rotIncrement);
                    nextEvent = Single.Parse(currentEvent.ChildNodes[3].InnerText);
                    break;
                case "garbage":
                    enemySpawner.SpawnGarbageTruck();
                    nextEvent = Single.Parse(currentEvent.ChildNodes[1].InnerText);
                    break;
                case "cop":
                    enemySpawner.SpawnCopCar();
                    nextEvent = Single.Parse(currentEvent.ChildNodes[1].InnerText);
                    break;
                case "ambulance":
                    enemySpawner.SpawnAmbulance();
                    nextEvent = Single.Parse(currentEvent.ChildNodes[1].InnerText);
                    break;
                case "turret":
                    enemySpawner.SpawnTurret();
                    nextEvent = Single.Parse(currentEvent.ChildNodes[1].InnerText);
                    break;
                case "ped":
                    enemySpawner.SpawnPedestrian();
                    nextEvent = Single.Parse(currentEvent.ChildNodes[1].InnerText);
                    break;
                case "car":
                    enemySpawner.SpawnCar();
                    nextEvent = Single.Parse(currentEvent.ChildNodes[1].InnerText);
                    break;
            }
            bookmark++;
            yield return new WaitForSeconds(nextEvent);
        }
	
	}
}
