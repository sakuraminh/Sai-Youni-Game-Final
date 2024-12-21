using UnityEngine;
using UnityEngine.Events;

public class BaseGameEventListener<T, E, UER> : MMonoBehaviour, IGameEventListener<T> where E : BaseGameEvent<T> where UER : UnityEvent<T>
{
    [SerializeField] private E gameEvent = null;
    public E GameEvent { get { return gameEvent; } set { gameEvent = value; } }

    [SerializeField] protected UER unityEventResponse;
    public UER UnityEventResponse => this.unityEventResponse;

    protected override void OnEnable()
    {
        if (gameEvent == null) { return; }

        GameEvent.RegisterListener(this);
    }

    protected override void OnDisable()
    {
        if (gameEvent == null) return;

        GameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(T item)
    {
        if (unityEventResponse != null)
        {
            unityEventResponse.Invoke(item);
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadgameEvent();
    }
    protected virtual void LoadgameEvent()
    {
        //
    }



}
