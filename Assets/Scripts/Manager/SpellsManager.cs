using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellsManager : MonoBehaviour
{
    private Dictionary<string, GameObject> _spellsList = new Dictionary<string, GameObject>();
    [SerializeField] private List<GameObject> _spellsInstance;

    private float basicSpeedOfSpell;
    private float basicDurationOfSpell;

    private void Start()
    {
        _SetSpellsList();
        basicSpeedOfSpell = 2.0f;
        basicDurationOfSpell = 7.0f;
    }

    private void _SetSpellsList()
    {
        if (_spellsInstance.Count < 1)
            return;
        _spellsList.Add("fire_cross", _spellsInstance[0]);
        _spellsList.Add("fire cross", _spellsInstance[0]);
    }

    public void CastSpells(string spellName, Transform casterPosition)
    {
        if (!_spellsList.ContainsKey(spellName))
            return;
        switch(spellName)
        {
            case "fire_cross":
                _CastFireCross(_spellsList[spellName], casterPosition);
                break;
            case "fire cross":
                _CastFireCross(_spellsList[spellName], casterPosition);
                break;
        }
    }

    private void _CastFireCross(GameObject firecross, Transform position)
    {
        GameObject newSpell = Instantiate(firecross, position, true);
        Rigidbody rg = newSpell.GetComponent<Rigidbody>();

        newSpell.transform.parent = null;
        newSpell.transform.position = new Vector3(position.position.x, position.position.y, position.position.z);
        newSpell.transform.Rotate(new Vector3(position.rotation.eulerAngles.x, position.rotation.eulerAngles.y, position.rotation.eulerAngles.z));
        rg.velocity = newSpell.transform.forward * basicSpeedOfSpell;
        Destroy(newSpell, basicDurationOfSpell);
    }
}
