using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AnimationSequenceObject {

    private IAnimation _iAnimation;
    public IAnimation IAnimation { 
        get {
            if (_iAnimation == null) {
                _iAnimation = animationObject.GetComponent<IAnimation>();
            }

            return _iAnimation;
        }
    }

    public GameObject animationObject;
    public float appearDelay;
    public float disappearDelay;

}
