using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 实体创建工厂类，用于创建不同类型的实体
public class EntityFactory : BaseMgr<EntityFactory>
{

    public Entity CreateEntity(eEntityType entityType, long entityID)
    {
        Entity entity = null;

        switch(entityType)
        {
            case eEntityType.PLAYER_MAIN:
                entity = new EntityMainPlayer();
                break;
            case eEntityType.NPC:
                entity = new EntityNpc();
                break;
            default:
                Debug.LogError("failed to create entity type " + entityType.ToString());
                break;
        }

        entity.SetID(entityID);

        return entity;
    }
}
