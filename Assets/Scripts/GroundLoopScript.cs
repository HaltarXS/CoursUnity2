using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GroundLoopScript : MonoBehaviour {


    private List<Transform> groundPart;

    // Use this for initialization
    void Start()
    {
        groundPart = new List<Transform>();

        for (int i = 0; i < transform.childCount; i++)
        {

            Transform child = transform.GetChild(i);

            if (child.renderer != null)
            {
                groundPart.Add(child);
            }
        }
        
        groundPart = groundPart.OrderBy(
                t => t.position.z
                ).ToList();
    }

    // Update is called once per frame
    void Update()
    {
        Transform firstChild = groundPart.First();

        if (firstChild != null)
        {
            Vector3 firstChildPos = new Vector3(firstChild.position.x, firstChild.position.y, firstChild.position.z + firstChild.renderer.bounds.size.z);
            Vector3 firstChildPosPix = Camera.main.WorldToScreenPoint(firstChildPos);
            if (firstChildPosPix.x <= 0)
            {
                // On récupère le dernier élément de la liste
                Transform lastChild = groundPart.LastOrDefault();

                // On calcule ainsi la position à laquelle nous allons replacer notre morceau
                Vector3 lastSize = (lastChild.renderer.bounds.max - lastChild.renderer.bounds.min);
                // On place le morceau tout à la fin
                // Note : ne fonctionne que pour un scorlling horizontal
                firstChild.position = new Vector3(firstChild.position.x, firstChild.position.y, lastChild.position.z + +lastSize.z);

                // On met à jour la liste (le premier devient dernier)
                groundPart.Remove(firstChild);
                groundPart.Add(firstChild);
            }


        }
    }
}
