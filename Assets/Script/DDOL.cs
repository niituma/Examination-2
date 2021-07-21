using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL : MonoBehaviour
{
        void Start()
        {
            if (FindObjectsOfType<DDOL>().Length > 1)
            {
                // 重複しないように、既にある時は自分自身を破棄する
                Destroy(this.gameObject);
            }
            else
            {
                // 自分しかいない時は、自分を DontDestroyOnLoad に登録する
                DontDestroyOnLoad(this.gameObject);
            }
        }

    }
