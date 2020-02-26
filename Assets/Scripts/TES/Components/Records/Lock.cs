﻿using TESUnity.ESM;

namespace TESUnity.Components.Records
{
    public class Lock : RecordComponent
    {
        void Start()
        {
            usable = true;
            pickable = false;
            var LOCK = (LOCKRecord)record;
            //objData.icon = TESUnity.instance.Engine.textureManager.LoadTexture(WPDT.ITEX.value, "icons"); 
            objData.name = LOCK.FNAM.value;
            objData.weight = LOCK.LKDT.weight.ToString();
            objData.value = LOCK.LKDT.value.ToString();
        }
    }
}