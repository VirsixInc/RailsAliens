using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

	//ObjectPool should be used for objects that are spawned many times through out a level - projectiles or common enemies, squibs, etc, to converse performance power.
	
	public GameObject[] pooledGameObjects; //note: these objects must be set to inactive in order for pool to function properly
	public int[] numberOfObjectsToPool; //how many of each type of object you want pooled - set in the inspector
	public List<GameObject>[] pool; //holds all of the lists of disabled objects
	
	
	void Awake () {
		InstantiateObjects();
	}

	private void InstantiateObjects() {
		GameObject temp;
		pool = new List<GameObject>[pooledGameObjects.Length];

		for (int count = 0; count < pooledGameObjects.Length; count++) {			//however many gameobjects are getting pooled, make a list for each one
			pool[count] = new List<GameObject>();									
			
			for (int num = 0; num < numberOfObjectsToPool[count]; num++) { 			//for however many objects of each type
				temp = (GameObject)Instantiate(pooledGameObjects[count]);			
				temp.transform.parent = this.transform; 							//keeps hierarchy clean by putting pooled objs under component transform
				pool[count].Add(temp);
			}
		}
	}
	
	public GameObject Activate(int id, Vector3 position, Quaternion rotation) {
		for (int count = 0; count < pool[id].Count; count++) {
			if(!pool[id][count].activeSelf){									
				pool[id][count].SetActive(true);									//activates objects instead of instanciating them
				pool[id][count].transform.position = position;
				pool[id][count].transform.rotation = rotation;
				pool[id][count].transform.parent = this.transform;
	
				return pool[id][count];
			}
		}

		pool[id].Add((GameObject)Instantiate(pooledGameObjects[id]));				//in case pool is depleted add new objects
		pool[id][pool[id].Count-1].transform.position = position;  
		pool[id][pool[id].Count-1].transform.rotation = rotation;	 
		pool[id][pool[id].Count-1].transform.parent = this.transform;
		return pool[id][pool[id].Count-1];
	}
	
	public void Deactivate(GameObject deactivateObject)
	{
		deactivateObject.SetActive(false);
	}
}