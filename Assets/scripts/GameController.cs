using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
    public GameObject commanderPrefab, privatePrefab, zaznaczeniePrefab;
    CommanderMovement commanderMovement;

	void Update () {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "dowodca")
                {
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().characterToFollow = hit.collider.gameObject;

                    if (commanderMovement != null)
                    {
                        Destroy(commanderMovement.selection);
                        commanderMovement.selection = null;
                        commanderMovement.isSelected = false;
                    }

                    commanderMovement = hit.collider.transform.parent.GetComponent<CommanderMovement>();

                    if (commanderMovement != null)
                    {
                        commanderMovement.selection = Instantiate(zaznaczeniePrefab, 
                            commanderMovement.gameObject.transform.position, 
                            zaznaczeniePrefab.transform.rotation, 
                            commanderMovement.gameObject.transform) as GameObject;
                        commanderMovement.isSelected = true;
                    }
                }
                else
                {
                    if (commanderMovement != null)
                    {
                        Destroy(commanderMovement.selection);
                        commanderMovement.selection = null;
                        commanderMovement.isSelected = false;
                        commanderMovement = null;
                    }

                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().characterToFollow = null;
                }
            }
        }
	}
}
