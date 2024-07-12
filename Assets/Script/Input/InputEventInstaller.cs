using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class InputEventInstaller : MonoInstaller
{
    [SerializeField] private Button _launchButton ;
    
    public override void InstallBindings()
    {
//#if UNITY_EDITOR
/*
        Container.Bind(typeof(IInputEventProvider), 
                typeof(IInitializable), typeof(IDisposable))
            .To<MouseInputProvider>().AsSingle().WithArguments(_launchButton);
*/
//#elif UNITY_ANDROID
        Container.Bind(typeof(IInputEventProvider), 
                typeof(IInitializable), typeof(IDisposable))
            .To<PhysicalButtonsInputEventProvider>().AsSingle();
//#endif
    }
}