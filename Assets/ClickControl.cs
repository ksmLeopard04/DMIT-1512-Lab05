using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class ClickControl : MonoBehaviour, IPointerClickHandler
{
    int enemyPathMask = 1 << 3;
    int towerMask = 1 << 4;

    public void OnPointerClick(PointerEventData eventData)
    {
        NavMeshHit hit;
        NavMesh.SamplePosition(eventData.pointerCurrentRaycast.worldPosition, out hit, 0.1f, NavMesh.AllAreas);
        if (hit.mask == towerMask && eventData.button == PointerEventData.InputButton.Left)
        {
            GameObject tower = ObjectPool.SharedInstance.GetPooledObject(2);
            if(tower != null)
            {
                tower.transform.position = hit.position;
                tower.transform.rotation = Quaternion.identity;
                tower.SetActive(true);
            }
        }
        else if (hit.mask == enemyPathMask && eventData.button == PointerEventData.InputButton.Right)
        {
            GameObject mine = ObjectPool.SharedInstance.GetPooledObject(4);
            if(mine != null)
            {
                mine.transform.position = hit.position;
                mine.transform.rotation = Quaternion.identity;
                mine.SetActive(true);
            }
        }
    }
}
