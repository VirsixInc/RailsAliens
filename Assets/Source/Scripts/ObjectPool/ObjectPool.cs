using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {
	
	public GameObject[] pooledGameObjects; //note: these objects must be set to inactive in inspector or elsewhere in order for this to function properly
	public int[] numberOfProjectilesToCreate;
	public List<GameObject>[] pool;
	
	
	// Use this for initialization
	void Awake () {
		InstantiateObjects();
	}

	private void InstantiateObjects() {
		GameObject temp;
		pool = new List<GameObject>[pooledGameObjects.Length];

		for (int count = 0; count < pooledGameObjects.Length; count++) {			//however many gameobjects are getting pooled, make a list for each one
			pool[count] = new List<GameObject>();									
			
			for (int num = 0; num < numberOfProjectilesToCreate[count]; num++){ 	//for however many objects of each type
				temp = (GameObject)Instantiate(pooledGameObjects[count]);			
				temp.transform.parent = this.transform; 							//keeps hierarchy clean by putting pooled objs under component transform
				pool[count].Add(temp);
			}
		}
	}
	
	public GameObject Activate(int id, Vector3 position, Quaternion rotation) {
		for (int count = 0; count < pool[id].Count; count++) {
			if(!pool[id][count].activeSelf){									//activates objects instead of instanciating them
				pool[id][count].SetActive(true);
				pool[id][count].transform.position = position;
				pool[id][count].transform.rotation = rotation;
				pool[id][count].transform.parent = this.transform;
	
				return pool[id][count];
			}
		}
		pool[id].Add((GameObject)Instantiate(pooledGameObjects[id])); //incase pool runs out
		pool[id][pool[id].Count-1].transform.position = position;     //instantiate objects the regular way
		pool[id][pool[id].Count-1].transform.rotation = rotation;	   //last resort but better than buffer running out
		pool[id][pool[id].Count-1].transform.parent = this.transform;
		return pool[id][pool[id].Count-1];
	}
	
	public void Deactivate(GameObject deactivateObject)
	{
		deactivateObject.SetActive(false);
	}
}