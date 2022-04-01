using UnityEngine;

public class PositionRendererSorter : MonoBehaviour
{
   [SerializeField] private int sortingOrderBase = 300,offset = 0;
   [SerializeField] private bool runOnlyOnce = false;
   [SerializeField] private Renderer renderer;

   private float timer,timerMax = 0.1f;

   private void FixedUpdate()
   {
      timer -= Time.deltaTime;
      if (timer <= 0f)
      {
         timer = timerMax;
         renderer.sortingOrder = (int) (sortingOrderBase - (transform.position.y - offset));
         if (runOnlyOnce) Destroy(this);
      }
   }
}
