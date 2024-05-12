using UnityEngine;
using UnityEditor;

//Put this under a folder called Editor in your project
public class EmptyGOCreator
{
    [MenuItem("Tools/GameObjectTools/Create Empty at level %#g")]
    static void CreateEmptyGOAtLevel()
    {
        var go = new GameObject("GameObject");
        Undo.RecordObject(go, "Create Empty At level");
        go.transform.parent = Selection.activeGameObject == null ? null : Selection.activeGameObject.transform.parent;
        go.transform.position = Vector3.zero;
    }

    [MenuItem("Tools/GameObjectTools/Create Empty below level &#g")]
    static void CreateEmptyGOAsChild()
    {
        var gObjs = Selection.gameObjects;
        Undo.RecordObjects(gObjs, "remove empty below level");
        for (int i = 0; i < gObjs.Length; i++)
        {
            var go = new GameObject("child of " + gObjs[i].name);

            go.transform.parent = gObjs[i] == null ? null : gObjs[i].transform;
            go.transform.localPosition = Vector3.zero;
            go.transform.localRotation = Quaternion.identity;
            go.transform.localScale = Vector3.one;
        }
    }

    [MenuItem("Tools/GameObjectTools/Rename First Child of selected with parent name")]
    static void RenameFirstChildOfSelected()
    {
        var gObjs = (Selection.gameObjects == null) ? null : Selection.gameObjects;
        Undo.RecordObjects(gObjs, "undo renaming children");
        if (gObjs == null)
        {
            Debug.LogError("Must Select objects in the hierarchy");
            return;
        }
        for (int i = 0; i < gObjs.Length; i++)
        {
            GameObject child = gObjs[i].transform.GetChild(0).gameObject;
            Undo.RecordObject(child, "rename child");
            string childName = child.name;
            child.name = gObjs[i].name + " " + childName;
        }
    }

    [MenuItem("Tools/GameObjectTools/Rename selected by appending to parent's name")]
    static void RenameWithParentNamePrepended()
    {
        var gObjs = (Selection.gameObjects == null) ? null : Selection.gameObjects;
        Undo.RecordObjects(gObjs, "undo renaming children");
        if (gObjs == null)
        {
            Debug.LogError("Must Select objects in the hierarchy");
            return;
        }
        for (int i = 0; i < gObjs.Length; i++)
        {
            GameObject parent = gObjs[i].transform.parent.gameObject;
            gObjs[i].name = parent.name + gObjs[i].name;
        }
    }

    [MenuItem("Tools/GameObjectTools/Make selected into children of new objects at same level and same transform")]
    static void MakeSelectedIntoNewChildrenWithTransform()
    {
        var gObjs = Selection.gameObjects;
        for (int i = 0; i < gObjs.Length; i++)
        {
            var go = new GameObject("parent " + gObjs[i].name);
            Undo.RecordObject(go, "revert children transform");
            go.transform.parent = gObjs[i].transform.parent;
            go.transform.position = gObjs[i].transform.position;
            go.transform.rotation = gObjs[i].transform.rotation;
            gObjs[i].transform.parent = go.transform;
        }
    }

    [MenuItem("Tools/GameObjectTools/Make selected into children of new objects at same level")]
    static void MakeSelectedIntoNewChildren()
    {
        var gObjs = Selection.gameObjects;
        Undo.RecordObjects(gObjs, " undo make into children");
        for (int i = 0; i < gObjs.Length; i++)
        {
            var go = new GameObject("GameObject");
            go.transform.parent = gObjs[i].transform.parent;
            go.transform.localPosition = Vector3.zero;
            gObjs[i].transform.parent = go.transform;
        }
    }

    [MenuItem("Tools/GameObjectTools/remove all components but sprite renderers on selected")]
    static void StripToSpriteRenderer()
    {
        GameObject root;
        if (GameObject.Find("CenterPoint"))
            root = GameObject.Find("CenterPoint");
        else
        {
            root = new GameObject("CenterPoint");
            root.transform.position = Vector3.zero;
        }
        var gObjs = Selection.gameObjects;
        for (int i = 0; i < gObjs.Length; i++)
        {
            if (gObjs[i].transform.childCount > 0)
            {

                for (int j = 0; j < gObjs[i].transform.childCount; j++)
                {
                    if (gObjs[i].transform.GetChild(j).GetComponent<SpriteRenderer>())
                    {
                        var go = new GameObject("clone_" + gObjs[i].transform.GetChild(j).name);
                        go.transform.parent = root.transform;
                        go.transform.position = gObjs[i].transform.GetChild(j).transform.position;
                        go.transform.rotation = gObjs[i].transform.GetChild(j).transform.rotation;
                        go.transform.localScale = gObjs[i].transform.GetChild(j).transform.localScale;
                        go.AddComponent<SpriteRenderer>();
                        go.GetComponent<SpriteRenderer>().sprite = gObjs[i].transform.GetChild(j).GetComponent<SpriteRenderer>().sprite;
                        go.GetComponent<SpriteRenderer>().color = gObjs[i].transform.GetChild(j).GetComponent<SpriteRenderer>().color;
                        GameObject.DestroyImmediate(gObjs[i].transform.GetChild(j).gameObject);
                    }
                }
            }
            if (gObjs[i].GetComponent<SpriteRenderer>())
            {
                var go = new GameObject("clone_" + gObjs[i].name);
                go.transform.parent = root.transform;
                go.transform.position = gObjs[i].transform.position;
                go.transform.rotation = gObjs[i].transform.rotation;
                go.transform.localScale = gObjs[i].transform.localScale;
                go.AddComponent<SpriteRenderer>();
                go.GetComponent<SpriteRenderer>().sprite = gObjs[i].GetComponent<SpriteRenderer>().sprite;
                go.GetComponent<SpriteRenderer>().color = gObjs[i].GetComponent<SpriteRenderer>().color;
                GameObject.DestroyImmediate(gObjs[i]);
            }
        }
    }

    [MenuItem("Tools/GameObjectTools/Unparent children of All Selected")]
    static void UnParentSelectedToRoot()
    {
        var gObjs = Selection.gameObjects;
        for (int i = 0; i < gObjs.Length; i++)
        {
            if (gObjs[i].transform.childCount > 0)
            {
                for (int j = 0; j <= gObjs[i].transform.childCount - 1; j++)
                {
                    gObjs[i].transform.GetChild(j).gameObject.transform.parent = gObjs[i].transform.root;
                }
            }
            else gObjs[i].transform.parent = gObjs[i].transform.root;
        }
    }

    [MenuItem("Tools/GameObjectTools/Unparent children selected and move up one level")]
    static void UnParentSelected()
    {
        var gObjs = Selection.gameObjects;
        for (int i = 0; i < gObjs.Length; i++)
        {
            if (gObjs[i].transform.childCount > 0)
            {
                for (int j = 0; j <= gObjs[i].transform.childCount - 1; j++)
                {
                    gObjs[i].transform.GetChild(j).gameObject.transform.parent = gObjs[i].transform.parent;
                }
            }

        }
    }

    [MenuItem("Tools/GameObjectTools/Unparent children of selected and destroy parent")]
    static void UnParentSelectedAndDestroy()
    {
        var gObjs = Selection.gameObjects;
        for (int i = 0; i < gObjs.Length; i++)
        {
            if (gObjs[i].transform.childCount > 0)
            {
                for (int j = 0; j <= gObjs[i].transform.childCount - 1; j++)
                {
                    gObjs[i].transform.GetChild(j).gameObject.transform.parent = gObjs[i].transform.parent;
                }
            }
        }
        for (int i = 0; i < gObjs.Length; i++)
        {
            GameObject.DestroyImmediate(gObjs[i]);
        }
    }

    [MenuItem("Tools/GameObjectTools/Unparent children of selected, move to root, and destroy parent")]
    static void UnParentSelectedRootAndDestroy()
    {
        var gObjs = Selection.gameObjects;
        for (int i = 0; i < gObjs.Length; i++)
        {
            if (gObjs[i].transform.childCount > 0)
            {
                for (int j = 0; j <= gObjs[i].transform.childCount - 1; j++)
                {
                    gObjs[i].transform.GetChild(j).gameObject.transform.parent = gObjs[i].transform.root;
                }
            }
        }
        for (int i = 0; i < gObjs.Length; i++)
        {
            GameObject.DestroyImmediate(gObjs[i]);
        }
    }

    [MenuItem("Tools/GameObjectTools/Delete first child of all selected")]
    static void DeleteChildrenOfSelected()
    {
        var gObjs = Selection.gameObjects;
        for (int i = 0; i < gObjs.Length; i++)
        {
            GameObject.DestroyImmediate(gObjs[i].transform.GetChild(0).gameObject);
        }
    }

    [MenuItem("Tools/GameObjectTools/Add Circle Collider to children of selected")]
    static void AddCircleColliderToChildrenOfSelected()
    {
        var gObjs = Selection.gameObjects;
        for (int i = 0; i < gObjs.Length; i++)
        {
            gObjs[i].transform.GetChild(0).gameObject.AddComponent<CircleCollider2D>();
        }
    }

    [MenuItem("Tools/GameObjectTools/Toggle SpriteRenderer on selected object %u")]
    static void ToggleSpriteRendererOnSelectedObjects()
    {
        SpriteRenderer spr = Selection.activeGameObject == null ? null : Selection.activeGameObject.GetComponent<SpriteRenderer>();
        Undo.RecordObject(spr, "toggle sprite renderer");
        if (spr.enabled == false)
            spr.enabled = true;
        else
            spr.enabled = false;
    }

    [MenuItem("Tools/GameObjectTools/Toggle GameObject Active on all selected %g")]
    static void ToggleGameObjActiveOnSelected()
    {
        var gObjs = (Selection.gameObjects == null) ? null : Selection.gameObjects;
        Undo.RecordObjects(gObjs, "undo gameobject toggle");
        if (gObjs == null)
        {
            Debug.LogError("Must Select objects in the hierarchy");
            return;
        }
        for (int i = 0; i < gObjs.Length; i++)
        {
            gObjs[i].SetActive(!gObjs[i].activeInHierarchy);
        }
    }

    [MenuItem("Tools/GameObjectTools/Add Box2D Collider to children of selected")]
    static void AddBox2DColliderToChildrenOfSelected()
    {
        var gObjs = Selection.gameObjects;
        Undo.RecordObjects(gObjs, "remove box colliders");
        for (int i = 0; i < gObjs.Length; i++)
        {
            gObjs[i].transform.GetChild(0).gameObject.AddComponent<EdgeCollider2D>();
            gObjs[i].transform.GetChild(0).gameObject.GetComponent<EdgeCollider2D>().points = new Vector2[2] {
                new Vector2 (-0.13f, 0),
                new Vector2 (0.13f, 0)
            };
        }
    }

    [MenuItem("Tools/GameObjectTools/Add BoxCollider2D to all selected")]
    static void AddBoxCollider2DToSelection()
    {
        var gObjs = Selection.gameObjects;
        Undo.RecordObjects(gObjs, "undo boxcollider2d add");
        for (int i = 0; i < gObjs.Length; i++)
        {
            gObjs[i].AddComponent<BoxCollider2D>();
        }
    }
}