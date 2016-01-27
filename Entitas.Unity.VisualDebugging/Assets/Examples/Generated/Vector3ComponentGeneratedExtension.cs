namespace Entitas {
    public partial class Entity {
        public Vector3Component vector3 { get { return (Vector3Component)GetComponent(ComponentIds.Vector3); } }

        public bool hasVector3 { get { return HasComponent(ComponentIds.Vector3); } }

        public Entity AddVector3(UnityEngine.Vector3 newVector3) {
            var componentPool = GetComponentPool(ComponentIds.Vector3);
            var component = (Vector3Component)(componentPool.Count > 0 ? componentPool.Pop() : new Vector3Component());
            component.vector3 = newVector3;
            return AddComponent(ComponentIds.Vector3, component);
        }

        public Entity ReplaceVector3(UnityEngine.Vector3 newVector3) {
            var componentPool = GetComponentPool(ComponentIds.Vector3);
            var component = (Vector3Component)(componentPool.Count > 0 ? componentPool.Pop() : new Vector3Component());
            component.vector3 = newVector3;
            ReplaceComponent(ComponentIds.Vector3, component);
            return this;
        }

        public Entity RemoveVector3() {
            return RemoveComponent(ComponentIds.Vector3);;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherVector3;

        public static IMatcher Vector3 {
            get {
                if (_matcherVector3 == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Vector3);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherVector3 = matcher;
                }

                return _matcherVector3;
            }
        }
    }
}