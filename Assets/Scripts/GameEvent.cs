using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameEvent
{
    public Communicator onChangedCamera = new Communicator();
    public Communicator<CharacterComponent.Direction> onMoveCharacter = new Communicator<CharacterComponent.Direction>();
}
