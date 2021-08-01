using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    public class RayCastDraw
    {
        public static GameObject RayInteraction(Vector3 StartingPoint, Vector3 Point, float Range)
        {
            GameObject _ret = null;
            RaycastHit _HitInfo;
            if (Physics.Raycast(StartingPoint, Point, out _HitInfo, Range))
            {
                if (_HitInfo.transform.tag == "Object" || _HitInfo.transform.tag == "Door")
                {
                    _ret = _HitInfo.transform.gameObject;
                }

                //  Debug.Log(_ret.name);
            }
            return _ret;
        }


        public static GameObject RayMelee(Vector3 StartingPoint, Vector3 Point, float Range)
        {
            GameObject _ret = null;
            RaycastHit _HitInfo;
            if (Physics.Raycast(StartingPoint, Point, out _HitInfo, Range))
            {
                _ret = _HitInfo.transform.gameObject;
            }
            return _ret;
        }

        public static bool RayInterceptionCheck(Vector3 StartingPoint, GameObject Target, float distance)
        {
            bool _ret = false;
            RaycastHit hit;
            Vector3 Raydiraction = Target.transform.position - StartingPoint;
            if (Physics.Raycast(StartingPoint, Raydiraction, out hit))
            {
                //Debug.Log(hit.transform.root.gameObject.name);
                if (hit.transform.root.gameObject == Target)
                {
                    float _dis = Vector3.Distance(StartingPoint, Target.transform.position);
                    if (_dis < distance)
                    {
                        return true;
                    }
                }

            }
            return _ret;
        }

        public static bool RayInterceptionCheck_ViewArc(GameObject StartingPoint, GameObject Target, float Arc)
        {
            bool _ret = false;
            RaycastHit hit;
            Vector3 Raydiraction = Target.transform.position - StartingPoint.transform.position;
            if (Physics.Raycast(StartingPoint.transform.position, Raydiraction, out hit))
            {
                //Debug.Log(hit.transform.root.gameObject.name);
                if (hit.transform.root.gameObject == Target)
                {
                    //float _dis = Vector3.Distance(StartingPoint, Target.transform.position);
                    ////Debug.Log(_dis);
                    //if (_dis < distance)
                    //{
                    //    return false;
                    //}
                    float angel = Vector3.Angle(StartingPoint.transform.forward, Target.transform.position - StartingPoint.transform.position); //TargetPoint.position  Target.transform.position
                                                                                                                                                // Debug.Log((Mathf.Abs(angel)));
                    if (Mathf.Abs(angel) > 1 && Mathf.Abs(angel) < Arc)
                    {

                        return true;
                    }
                }

            }
            return _ret;
        }

        public static RaycastHit RayBullet(Vector3 StartingPoint, Vector3 Point, float Range)
        {

            RaycastHit _HitInfo;
            if (Physics.Raycast(StartingPoint, Point, out _HitInfo, Range, LayerMask.GetMask("Default")))
            {
                return _HitInfo;
            }
            else
            {

            }

            return _HitInfo;
        }
    }
}
