using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI_1
{
    public class Component
    {
        private List<IFieldSubscription> _subscriptions = new();

        public T Use<T>(ObservableField<T> field) // использовать в компоненте свойство ObservableField (компонент будет наблюдать за изменением ObservableField)
        {
            field.Subscribe(this);
            _subscriptions.Add(new FieldSubscription<T>(field, this));
            return field.Value;
        }

        public void Use<T>(ObservableField<T> field, out T value)
        {
            field.Subscribe(this);
            _subscriptions.Add(new FieldSubscription<T>(field, this));
            value = field.Value;
        }

        // Универсальный интерфейс для хранения подписок
        private interface IFieldSubscription
        {
            void Unsubscribe();
        }

        // сохраняем и компонент и ObservableField чтобы потом удобно отписаться
        private class FieldSubscription<T> : IFieldSubscription
        {
            private ObservableField<T> _field;
            private Component _component;

            public FieldSubscription(ObservableField<T> field, Component component)
            {
                _field = field;
                _component = component;
            }

            public void Unsubscribe()
            {
                _field.Unsubscribe(_component);
            }
        }

        public virtual void Dispose() // при уничтожении компонента он отпишется от всех ObservableField
        {
            foreach (var sub in _subscriptions)
                sub.Unsubscribe();

            _subscriptions.Clear();
        }

        public virtual void Render() { }
    }


    public class ComponentNamed : Component
    {
        public UINames Name { get; private set; }

        public ComponentNamed(UINames UIName) : base() //дать компоненту имя и зарегистрировать его
        {
            Name = UIName;
            Components.Reg(this);
        }
    }



    public class Component2_1
    {
        public bool IsOpen { get; set; } = false;
        public void Open()
        {
            // проверяем наличие GameObject, если его нет то создаём
            IsOpen = true;
            Update();
        }
        public void Update()
        {
            // логика при обновлении
            // например изменяем отображаемое значение здоровья
        }
        public void Close()
        {
            IsOpen = false;
        }
        public void Destroy()
        {
            Close();
            // удаляем GameObject
        }
    }






    public class Component2
    {
        private GameObject view; // ссылка на UI-объект (если он есть)
        public bool IsOpen { get; private set; }

        public void Open(Transform parent)
        {
            if (view == null)
            {
                view = GameObject.Instantiate(GetPrefab(), parent);
                OnCreated(view); // инициализация
            }

            IsOpen = true;
            Update();
        }

        public void Update()
        {
            if (!IsOpen || view == null)
                return;

            OnUpdate(view);
        }

        public void Close()
        {
            if (!IsOpen)
                return;

            IsOpen = false;
            OnClosed(view); // отписки, скрытие и т.д.
        }

        public void Destroy()
        {
            Close();
            if (view != null)
            {
                GameObject.Destroy(view);
                view = null;
            }
        }

        // ---- точки расширения ----
        protected virtual GameObject GetPrefab() => null;
        protected virtual void OnCreated(GameObject view) { }
        protected virtual void OnUpdate(GameObject view) { }
        protected virtual void OnClosed(GameObject view) { }
    }





    public abstract class UIComponent<TProps> : MonoBehaviour
    {
        protected TProps Props;
        public GameObject Container;
        public GameObject View;

        public void Bind(TProps props)
        {
            Props = props;
        }

        public UIComponent<TChildProps> CreateChild<TChildProps, TChild>(GameObject prefab, Transform parent, TChildProps props) where TChild : UIComponent<TChildProps>
        {
            var go = GameObject.Instantiate(prefab, parent);
            var child = go.GetComponent<TChild>();
            child.Bind(props);
            child.OpenUI();
            return child;
        }

        public UIComponent<TProps> CreateContainer(GameObject container)
        {
            Container = container;
            UIComponent<TProps> UIComponentContainer = Container.AddComponent<UIComponent<TProps>>();
            // UIComponentContainer.UIComponent = this;

            return UIComponentContainer;
        }

        public void OpenUI()
        {
            // загрузить префаб View в gameObject
            // найти все вложенные UIComponent в View и сдлеать OpenUI() у них
            Render();
        }
        public void CloseUI() { }
        public void DestroyUI() { }
        public virtual void Render() { }
    }


    public class ComponentProfiles : UIComponent<Type>
    {
        private Dictionary<string, GameProfile> Profiles = new();

        // public ComponentProfiles(Type props) : base(props)
        // {
        //     // подписатся на данные из модели:
        //     // Profiles = Use(GameProfiles.Profiles); // хук Use автоматически подпишет на изменение Profiles
        // }

        public override void Render()
        {
            // очистить список отображаемых профилей 
            // имея Profiles обновить данные в View
            foreach (var profile in Profiles)
            {
                // CreateChild<string, ComponentProfile>(profilePrefab, profilesContainer, profile.Value.ProfileId);
                ComponentProfile componentProfile = new();
                Transform ProfilesContainer = View.transform.Find("контейнер для профилей");
                CreateContainer(ProfilesContainer.gameObject);
                componentProfile.OpenUI();
            }
        }
    }


    public class ComponentProfile : UIComponent<string>
    {
        private GameProfile Profile;

        // public ComponentProfile(string props) : base(props)
        // {
        //     // подписатся на данные из модели:
        //     // Profile = Use(GameProfiles.Profiles[Props.GameProfileName]); // хук Use автоматически подпишет на изменение Profile
        // }

        public override void Render()
        {
            // имея GameProfile Profile обновить данные в View
        }

        public void OnClickButton() { } // пример нажатие кнопки
    }



    public class UIProfile : MonoBehaviour
    {
        public Button OpenProfile;
        public Button DeleteProfile;

        void Start()
        {
            // OpenProfile.onClick.AddListener((props) => Debug.Log($"OpenProfile {props}"));
            // DeleteProfile.onClick.AddListener((props) => Debug.Log($"DeleteProfile {props}"));

            // OpenProfile.onClick.AddListener(() => Props.OpenProfile?.Invoke());
            // DeleteProfile.onClick.AddListener(() => Props.DeleteProfile?.Invoke());
        }
    }








    // public class ComponentProps { }

    // public class ComponentProfileProps
    // {
    //     public string GameProfileName;
    //     // public ComponentProfileProps(string name)
    //     // {
    //     //     GameProfileName = name;
    //     // }
    // }





    // public void Bind(ComponentProps props) { }
    // public void OpenUI(Transform parent) { }


    // public class Component
    // {
    //     public UINames Name { get; private set; }
    //     public Component(UINames UIName)
    //     {
    //         Name = UIName;
    //         Components.RegUI(this);
    //     }

    //     protected T GetParm<T>(ObservableField<T> observableField)
    //     {
    //         observableField.Subscribe(this);
    //         return observableField.Value;
    //     }

    //     public virtual void Render()
    //     {
    //         Debug.Log($"Rendering {Name}");
    //     }
    // }
}