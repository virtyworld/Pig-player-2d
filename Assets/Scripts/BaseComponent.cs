using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseComponent : MonoBehaviour
{
    protected IMediator mediator;

    public BaseComponent(IMediator mediator = null)
    {
        this.mediator = mediator;
    }

    public void SetMediator(IMediator mediator)
    {
        this.mediator = mediator;
    }
}
