using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using PDollarGestureRecognizer;
using System.IO;

public class MovementRecognizer : MonoBehaviour
{
    //public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean keepMove;
    public SteamVR_Input_Sources handType;
    
    public Transform movementSource;
    private float _thresholdDistanceNewPosition;

    private bool isGrabWand;
    private bool isMoving;
    private List<Vector3> _listPositions = new List<Vector3>();

    private List<Gesture> _listSpells = new List<Gesture>();

    [SerializeField] private SpellsManager _spellsManager;

    // DEBUG MODE
    [Header("DEBUG MODE")]
    public bool debugMode = false;
    public GameObject debugCubePrefab;
    public float timerCubeLife = 3f;
    public bool createSpellMode = false;
    public string newGestureName;
    //

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        isGrabWand = false;
        _thresholdDistanceNewPosition = 0.05f;
        keepMove.AddOnStateUpListener(TriggerUp, handType);
        keepMove.AddOnStateDownListener(TriggerDown, handType);

        LoadSpells();
    }

    private void LoadSpells()
    {
        string[] spellsGesturesFiles = Directory.GetFiles(Application.persistentDataPath, "*_Spell.xml");

        foreach (string spell in spellsGesturesFiles)
        {
            _listSpells.Add(GestureIO.ReadGestureFromFile(spell));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            UpdateMovement();
        }
    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is up");
        if (isGrabWand) {
            EndMovement();
        }
    }
    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is down");
        if (isGrabWand)
        {
            StartMovement();
        }
    }

    private void StartMovement()
    {
        isMoving = true;
        _listPositions.Clear();
        _listPositions.Add(movementSource.position);
        if (debugMode)
            SpawnDebugCube();
    }

    private void EndMovement()
    {
        isMoving = false;

        Point[] pointArray = new Point[_listPositions.Count];
        Vector2 tmpPos;

        for (int i = 0; i < _listPositions.Count; i++) {
            tmpPos = Camera.main.WorldToScreenPoint(_listPositions[i]);
            pointArray[i] = new Point(tmpPos.x, tmpPos.y, 0);
        }

        Gesture newGesture = new Gesture(pointArray);

        if (debugMode && createSpellMode)
        {
            CreateNewGesture(newGesture, pointArray);
        } else
        {
            RecognizeSpell(newGesture);
        }
    }

    private void UpdateMovement()
    {
        Vector3 lastPosition = _listPositions[_listPositions.Count - 1];

        if (Vector3.Distance(movementSource.position, lastPosition) > _thresholdDistanceNewPosition)
        {
            _listPositions.Add(movementSource.position);
            if (debugMode)
                SpawnDebugCube();
        }
    }

    private void RecognizeSpell(Gesture gesture)
    {
        Result result = PointCloudRecognizer.Classify(gesture, _listSpells.ToArray());

        Debug.Log("Spell recognize: " + result.GestureClass + ", " + result.Score);
        _spellsManager.CastSpells(result.GestureClass, GameObject.FindGameObjectWithTag("MainCamera").transform);
    }

    public void grabWand()
    {
        isGrabWand = !isGrabWand;
    }

    // DEBUG MODE FUNCTIONS
    private void SpawnDebugCube()
    {
        if (debugCubePrefab)
            Destroy(Instantiate(debugCubePrefab, movementSource.position, Quaternion.identity), timerCubeLife);
    }

    private void CreateNewGesture(Gesture newGesture, Point[] pointArray)
    {
        newGesture.Name = newGestureName;
        _listSpells.Add(newGesture);
        Debug.Log("Spell created: " + newGestureName);

        // Stock gesture for next games
        string filename = Application.persistentDataPath + "/" + newGestureName + "_Spell.xml";
        GestureIO.WriteGesture(pointArray, newGestureName, filename);
    }
    //
}
