using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellsManager : MonoBehaviour
{
    private Dictionary<string, GameObject> _spellsList = new Dictionary<string, GameObject>();
    [SerializeField] private List<GameObject> _spellsInstance;

    private void Start()
    {
        _SetSpellsList();
    }

    private void _SetSpellsList()
    {
        if (_spellsInstance.Count < 1)
            return;
        _spellsList.Add("fire_cross", _spellsInstance[0]);
        _spellsList.Add("fire cross", _spellsInstance[0]);
    }

    public void CastSpells(string spellName)
    {
        if (!_spellsList.ContainsKey(spellName))
            return;
        switch(spellName)
        {
            case "fire_cross":
                _CastFireCross(_spellsList[spellName]);
                break;
            case "fire cross":
                _CastFireCross(_spellsList[spellName]);
                break;
        }
    }

    private void _CastFireCross(GameObject firecross)
    {
        Debug.Log("FIRE CROSS!");
        Instantiate(firecross);
    }
}
